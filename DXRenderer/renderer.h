#pragma once

#include <d3d11.h>
#include <dxgi.h>
#include <stdint.h>
#include <map>
#include <vector>

extern "C" struct DXTexture
{
	uint32_t *bytes;
	int width;
	int height;
};

extern "C" struct DXMaterial
{
	DXTexture diffuse;
	DXTexture specular;
	DXTexture normal;
};

extern "C" struct DXModel
{
	//todo
};

struct RenderBuffer
{
	IDXGISwapChain *swapChain;
	ID3D11Texture2D *renderTexture;
	ID3D11RenderTargetView *renderTarget;
	D3D11_VIEWPORT viewport;
};

class Renderer
{
public:
	Renderer();
	~Renderer();

	bool InitD3D();
	void ShutdownD3D();

	int32_t GetPreviewBufferId();

	int32_t CreateRenderBuffer(HWND hWnd);
	void DestroyRenderBuffer(int32_t bufferId);
	void Resize(int32_t bufferId, uint32_t width, uint32_t height);

	void SetRenderBuffer(int32_t bufferId);

private:
	void ReleaseDevice();
	void ReleaseResources();
	void ReleaseBuffersAndSwapChains();

private:
	bool initialized;
	ID3D11Device *device;
	ID3D11DeviceContext *deviceContext;

	int32_t currentUnusedId;

	IDXGIFactory1 *dxgiFactory;

	std::map<int32_t, RenderBuffer> renderBuffers;

	static const uint32_t PREVIEW_TEXTURE_WIDTH;
	static const uint32_t PREVIEW_TEXTURE_HEIGHT;
};
