using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class RendererInterop
    {
        private const string RENDERER_LIB = "renderer.dll";

        [DllImport(RENDERER_LIB, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool Initialize();


    }
}
