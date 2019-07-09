using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

using SharpDX;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;

using Color = SharpDX.Color;
using D3DDevice = SharpDX.Direct3D11.Device;
using DXGIDevice = SharpDX.DXGI.Device;
using DXGIFactory = SharpDX.DXGI.Factory1;

namespace Editor.Renderer
{
    public class RenderBuffer
    {
        public SwapChain SwapChain { get; set; }
        public RenderTargetView RenderTargetView { get; set; }
        public DepthStencilView DepthStencilView { get; set; }
        public Viewport Viewport { get; set; }
        public bool Ready { get; set; }
    }

    public struct GDIDevice
    {
        public Surface1 Surface { get; set; }
        public Graphics Graphics { get; set; }
    }

    public class Renderer
    {
        private D3DDevice device;
        private DeviceContext deviceContext;
        private DXGIFactory factory;

        private Dictionary<int, RenderBuffer> renderBuffers;

        private int currentId;

        private bool initialized;

        public Renderer()
        {
            initialized = false;
            renderBuffers = new Dictionary<int, RenderBuffer>();
        }

        public bool Initialize()
        {
            DeviceCreationFlags flags = DeviceCreationFlags.None;
#if DEBUG
            flags |= DeviceCreationFlags.Debug;
#endif
            try
            {
                device = new D3DDevice(DriverType.Hardware, flags);
                deviceContext = device.ImmediateContext;

                factory = new DXGIFactory();
            }
            catch(SharpDXException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            currentId = 1;
            initialized = true;

            return true;
        }

        public void Destroy()
        {
            if(initialized)
            {
                int[] keys = renderBuffers.Keys.ToArray();
                foreach(int id in keys)
                {
                    DetachWindow(id);
                }
                renderBuffers.Clear();

                deviceContext.Dispose();
                device.Dispose();
                factory.Dispose();

                initialized = false;
            }
        }

        public int AttachWindow(IntPtr hWnd)
        {
            if (!initialized) return -1;

            RenderBuffer buffer = new RenderBuffer();
            buffer.Ready = false;
            int assignedId = currentId;
            currentId++;

            try
            {
                SwapChainDescription swapChainDescription = new SwapChainDescription()
                {
                    IsWindowed = true,
                    BufferCount = 2,
                    OutputHandle = hWnd,
                    SwapEffect = SwapEffect.Discard,
                    Usage = Usage.RenderTargetOutput,
                    Flags = SwapChainFlags.GdiCompatible,
                    ModeDescription = new ModeDescription(0, 0, new Rational(0, 1), Format.B8G8R8A8_UNorm),
                    SampleDescription = new SampleDescription(1, 0)
                };

                buffer.SwapChain = new SwapChain(factory, device, swapChainDescription);

                renderBuffers.Add(assignedId, buffer);

                return assignedId;
            }
            catch(SharpDXException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public void DetachWindow(int id)
        {
            if (!initialized) return;

            if (renderBuffers.ContainsKey(id))
            {
                RenderBuffer buffer = renderBuffers[id];
                buffer.RenderTargetView.Dispose();
                buffer.SwapChain.Dispose();
                buffer.DepthStencilView.Dispose();
                renderBuffers.Remove(id);
            }
        }

        public void Resize(int id, int width, int height)
        {
            if (!initialized) return;

            if (renderBuffers.ContainsKey(id))
            {
                RenderBuffer buffer = renderBuffers[id];

                deviceContext.ClearState();
                if(buffer.RenderTargetView != null)
                {
                    buffer.RenderTargetView.Dispose();
                }
                if(buffer.DepthStencilView != null)
                {
                    buffer.DepthStencilView.Dispose();
                }

                buffer.SwapChain.ResizeBuffers(0, 0, 0, Format.Unknown, SwapChainFlags.GdiCompatible);
                using (Texture2D backbuffer = Texture2D.FromSwapChain<Texture2D>(buffer.SwapChain, 0))
                {
                    buffer.RenderTargetView = new RenderTargetView(device, backbuffer);
                }

                Texture2DDescription texture2DDescription = new Texture2DDescription()
                {
                    ArraySize = 1,
                    Format = Format.D24_UNorm_S8_UInt,
                    CpuAccessFlags = CpuAccessFlags.None,
                    SampleDescription = new SampleDescription(1, 0),
                    BindFlags = BindFlags.DepthStencil,
                    MipLevels = 1,
                    Usage = ResourceUsage.Default,
                    OptionFlags = ResourceOptionFlags.None,
                    Width = width,
                    Height = height
                };
                using (Texture2D depthStencilTexture = new Texture2D(device, texture2DDescription))
                {
                    buffer.DepthStencilView = new DepthStencilView(device, depthStencilTexture);
                }

                buffer.Viewport = new Viewport(0, 0, width, height, 0, 1);
                buffer.Ready = true;
            }
        }

        public void BeginDraw(int id, Matrix4x4 view, Matrix4x4 projection, Color clearColor)
        {
            if (!initialized) return;
            if (renderBuffers.ContainsKey(id))
            {
                RenderBuffer buffer = renderBuffers[id];
                if(buffer.Ready)
                {
                    deviceContext.Rasterizer.SetViewport(buffer.Viewport);
                    deviceContext.OutputMerger.SetRenderTargets(buffer.DepthStencilView, buffer.RenderTargetView);
                    deviceContext.ClearRenderTargetView(buffer.RenderTargetView, clearColor);
                    deviceContext.ClearDepthStencilView(buffer.DepthStencilView, DepthStencilClearFlags.Depth, 1.0f, 0);
                }
            }
        }

        public void EndDraw(int id)
        {
            if (!initialized) return;
            if (renderBuffers.ContainsKey(id))
            {
                RenderBuffer buffer = renderBuffers[id];
                if(buffer.Ready)
                {
                    buffer.SwapChain.Present(0, PresentFlags.None);
                }
            }
        }

        public bool GetGDIDevice(int id, ref GDIDevice gdiDevice)
        {
            if (!initialized) return false;
            if (renderBuffers.ContainsKey(id))
            {
                RenderBuffer buffer = renderBuffers[id];
                if(buffer.Ready)
                {
                    gdiDevice.Surface = buffer.SwapChain.GetBackBuffer<Surface1>(0);
                    gdiDevice.Graphics = Graphics.FromHdc(gdiDevice.Surface.GetDC(false));
                    return true;
                }
            }
            return false;
        }

        public void ReleaseGDIDevice(ref GDIDevice device)
        {
            device.Graphics.Dispose();
            device.Surface.ReleaseDC();
            device.Surface.Dispose();
        }

        public void DrawModel(/*Model model*/)
        {

        }

        public Bitmap RenderPreview(/*Model model*/)
        {
            if (!initialized) return null;

            return null;
        }
    }
}
