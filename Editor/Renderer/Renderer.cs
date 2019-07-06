using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using Color = SharpDX.Color;
using D3DDevice = SharpDX.Direct3D11.Device;
using DXGIDevice = SharpDX.DXGI.Device;
using DXGIFactory = SharpDX.DXGI.Factory1;

namespace Editor.Renderer
{
    public struct RenderBuffer
    {
        public SwapChain SwapChain { get; set; }
        public RenderTargetView RenderTargetView { get; set; }
        public Viewport Viewport { get; set; }
        public bool Ready { get; set; }
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
            device = new D3DDevice(DriverType.Hardware, flags);
            deviceContext = device.ImmediateContext;

            factory = new DXGIFactory();

            currentId = 1;
            initialized = true;

            return true;
        }

        public void Destroy()
        {
            if(initialized)
            {
                foreach(RenderBuffer buffer in renderBuffers.Values)
                {
                    buffer.SwapChain.Dispose();
                }

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

            using (Texture2D backbuffer = Texture2D.FromSwapChain<Texture2D>(buffer.SwapChain, 0))
            {
                buffer.RenderTargetView = new RenderTargetView(device, backbuffer);
            }

            renderBuffers.Add(assignedId, buffer);

            return assignedId;
        }

        public void DetachWindow(int id)
        {
            if (!initialized) return;

            if (renderBuffers.ContainsKey(id))
            {
                RenderBuffer buffer = renderBuffers[id];
                buffer.RenderTargetView.Dispose();
                buffer.SwapChain.Dispose();
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
                buffer.RenderTargetView.Dispose();
                buffer.SwapChain.ResizeBuffers(0, 0, 0, Format.Unknown, SwapChainFlags.GdiCompatible);
                using (Texture2D backbuffer = Texture2D.FromSwapChain<Texture2D>(buffer.SwapChain, 0))
                {
                    buffer.RenderTargetView = new RenderTargetView(device, backbuffer);
                }

                buffer.Viewport = new Viewport(0, 0, width, height, 0, 1);
                buffer.Ready = true;
                renderBuffers[id] = buffer;
            }
        }

        public void BeginDraw(int id, Color clearColor)
        {
            if (!initialized) return;
            if (renderBuffers.ContainsKey(id))
            {
                RenderBuffer buffer = renderBuffers[id];
                if(buffer.Ready)
                {
                    deviceContext.Rasterizer.SetViewport(buffer.Viewport);
                    deviceContext.OutputMerger.SetRenderTargets(buffer.RenderTargetView);
                    deviceContext.ClearRenderTargetView(buffer.RenderTargetView, clearColor);
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

        public Bitmap RenderPreview(/*Model model*/)
        {
            if (!initialized) return null;

            return null;
        }
    }
}
