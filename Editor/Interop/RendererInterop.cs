using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    struct DXTexture
    {
        public byte[] bytes;
        public int width;
        public int height;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct DXMaterial
    {
        public DXTexture diffuse;
        public DXTexture specular;
        public DXTexture normal;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct DXModel
    {
        //todo
    }

    class RendererInterop
    {
        private const string RENDERER_LIB = "renderer.dll";

        [DllImport(RENDERER_LIB, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool Initialize();

        [DllImport(RENDERER_LIB, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Dispose();

        [DllImport(RENDERER_LIB, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint AttachRenderbuffer(IntPtr hWnd);

        [DllImport(RENDERER_LIB, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DetachRenderbuffer(uint renderID);

        [DllImport(RENDERER_LIB, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void ResizeRenderbuffer(uint renderID, uint width, uint height);

        [DllImport(RENDERER_LIB, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetRenderbufferMode(uint renderID, uint mode);

        [DllImport(RENDERER_LIB, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void RenderTexture(uint renderID, DXTexture texture);

        [DllImport(RENDERER_LIB, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void RenderMaterial(uint renderID, DXMaterial material);

        public static void RenderTexture(uint renderID, Texture texture)
        {
            DXTexture dxTex = new DXTexture();
            //dxTex.bytes = texture.TextureData;
            dxTex.width = texture.Width;
            dxTex.height = texture.Height;

            RenderTexture(renderID, dxTex);
        }
    }
}
