#pragma once

#include <d3d11.h>
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

	uint32_t GetPreviewBufferId();

	uint32_t CreateRenderBuffer();
	void Resize(uint32_t bufferId, uint32_t width, uint32_t height);

private:
	void ReleaseDevice();
	void ReleaseResources();
	void ReleaseBuffersAndSwapChains();

private:
	bool initialized;
	ID3D11Device *device;
	ID3D11DeviceContext *deviceContext;

	std::map<uint32_t, RenderBuffer> renderBuffers;

	static const uint32_t PREVIEW_TEXTURE_WIDTH;
	static const uint32_t PREVIEW_TEXTURE_HEIGHT;
};
