#include <stdint.h>
#include <Windows.h>
#include <assert.h>

#include <string>
#include <sstream>

#include "renderer.h"

BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved)
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

static Renderer renderer;

extern "C"
{
	bool Initialize()
	{
		//MessageBoxA(nullptr, "Test", "Test", MB_OK);

		renderer.InitD3D();

		return true;
	}

	void Dispose()
	{
		renderer.ShutdownD3D();
	}

	uint32_t AttachRenderbuffer(HWND hWnd)
	{
		return -1;
	}

	void DetachRenderbuffer(uint32_t renderID)
	{
		assert(renderID >= 0);
	}

	void ResizeRenderbuffer(uint32_t renderID, uint32_t width, uint32_t height)
	{
		assert(renderID >= 0);
	}

	void SetRenderbufferMode(uint32_t renderID, uint32_t mode)
	{
		assert(renderID >= 0);
	}

	void RenderTexture(uint32_t renderID, DXTexture texture)
	{
		assert(renderID >= 0);

		std::stringstream str;
		str << texture.width;

		MessageBoxA(nullptr, str.str().c_str(), "OH BOY!!!", MB_OK);
	}

	void RenderMaterial(uint32_t renderID, DXMaterial material)
	{
		assert(renderID >= 0);
	}

	DXTexture *RenderModelPreview(DXModel *model)
	{
		return nullptr;
	}
}
