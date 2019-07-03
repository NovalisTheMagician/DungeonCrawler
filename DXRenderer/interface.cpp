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
		return renderer.InitD3D();
	}

	void Dispose()
	{
		renderer.ShutdownD3D();
	}

	int32_t AttachRenderbuffer(HWND hWnd)
	{
		MessageBox(nullptr, L"Attachbuffer", L"Attachbuffer", MB_OK);
		return renderer.CreateRenderBuffer(hWnd);
	}

	void DetachRenderbuffer(int32_t bufferId)
	{
		assert(bufferId >= 0);
		renderer.DestroyRenderBuffer(bufferId);
	}

	void ResizeRenderbuffer(int32_t bufferId, uint32_t width, uint32_t height)
	{
		assert(bufferId >= 0);
		renderer.Resize(bufferId, width, height);
	}

	void SetRenderBuffer(int32_t bufferId)
	{
		assert(bufferId >= 0);
	}

	uint32_t GetPreviewBufferId()
	{
		return renderer.GetPreviewBufferId();
	}

	void SetRenderbufferMode(int32_t bufferId, uint32_t mode)
	{
		assert(bufferId >= 0);
	}

	void RenderTexture(int32_t bufferId, DXTexture texture)
	{
		assert(bufferId >= 0);

		std::stringstream str;
		str << texture.width;

		MessageBoxA(nullptr, str.str().c_str(), "OH BOY!!!", MB_OK);
	}

	void RenderMaterial(int32_t bufferId, DXMaterial material)
	{
		assert(bufferId >= 0);
	}

	DXTexture *RenderModelPreview(DXModel *model)
	{
		return nullptr;
	}
}
