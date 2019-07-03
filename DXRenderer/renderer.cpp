#include "renderer.h"

const uint32_t Renderer::PREVIEW_TEXTURE_WIDTH = 512;
const uint32_t Renderer::PREVIEW_TEXTURE_HEIGHT = 512;

Renderer::Renderer()
	: device(nullptr), deviceContext(nullptr), initialized(false), renderBuffers(), currentUnusedId(1)
{
}

Renderer::~Renderer()
{
}

bool Renderer::InitD3D()
{
	if (initialized) return false;

	D3D_FEATURE_LEVEL featureLevelRequested = D3D_FEATURE_LEVEL_11_0;
	UINT numLevels = 1;
	D3D_FEATURE_LEVEL featureLevelSupported;
	UINT flags = 0;
#ifdef _DEBUG
	flags |= D3D11_CREATE_DEVICE_DEBUG;
#endif

	if (FAILED(D3D11CreateDevice(nullptr, D3D_DRIVER_TYPE_HARDWARE, 
								nullptr, flags, &featureLevelRequested, 
								numLevels, D3D11_SDK_VERSION, &device, 
								&featureLevelSupported, &deviceContext)))
	{
		return false;
	}

	if (FAILED(CreateDXGIFactory1(__uuidof(IDXGIFactory1), reinterpret_cast<void**>(&dxgiFactory))))
	{
		ReleaseDevice();
		return false;
	}

	RenderBuffer previewBuffer = { 0 };

	D3D11_TEXTURE2D_DESC textureDesc = { 0 };
	textureDesc.BindFlags = D3D11_BIND_RENDER_TARGET;
	textureDesc.CPUAccessFlags = D3D11_CPU_ACCESS_READ;
	textureDesc.Width = PREVIEW_TEXTURE_WIDTH;
	textureDesc.Height = PREVIEW_TEXTURE_HEIGHT;
	textureDesc.Usage = D3D11_USAGE_STAGING;
	textureDesc.Format = DXGI_FORMAT_R8G8B8A8_UINT;
	textureDesc.ArraySize = 1;

	if (FAILED(device->CreateTexture2D(&textureDesc, nullptr, &previewBuffer.renderTexture)))
	{
		ReleaseDevice();
		return false;
	}

	if (FAILED(device->CreateRenderTargetView(previewBuffer.renderTexture, nullptr, &previewBuffer.renderTarget)))
	{
		ReleaseDevice();
		return false;
	}

	previewBuffer.viewport = { 0, 0, PREVIEW_TEXTURE_WIDTH, PREVIEW_TEXTURE_HEIGHT, 0, 1 };

	renderBuffers[0] = previewBuffer;

	initialized = true;
	return true;
}

void Renderer::ReleaseDevice()
{
	deviceContext->Release();
	delete deviceContext;

	device->Release();
	delete device;

	dxgiFactory->Release();
	delete dxgiFactory;
}

void Renderer::ReleaseBuffersAndSwapChains()
{
	for (auto const& [id, buffer] : renderBuffers)
	{
		buffer.renderTarget->Release();
		delete buffer.renderTarget;

		if (buffer.renderTexture)
		{
			buffer.renderTexture->Release();
			delete buffer.renderTexture;
		}

		if (buffer.swapChain)
		{
			buffer.swapChain->Release();
			delete buffer.swapChain;
		}
	}
}

void Renderer::ReleaseResources()
{

}

void Renderer::ShutdownD3D()
{
	if (!initialized) return;

	ReleaseResources();
	ReleaseBuffersAndSwapChains();
	ReleaseDevice();

	initialized = false;
}

int32_t Renderer::GetPreviewBufferId()
{
	return 0;
}

int32_t Renderer::CreateRenderBuffer(HWND hWnd)
{
	RenderBuffer buffer = { 0 };
	int32_t assignedId = currentUnusedId;
	currentUnusedId++;

	DXGI_SWAP_CHAIN_DESC swapchainDesc = { 0 };
	swapchainDesc.BufferCount = 2;
	swapchainDesc.BufferDesc = { 0 };
	swapchainDesc.SampleDesc = { 1, 0 };
	swapchainDesc.SwapEffect = DXGI_SWAP_EFFECT_DISCARD;
	swapchainDesc.OutputWindow = hWnd;
	swapchainDesc.Windowed = true;

	if (FAILED(dxgiFactory->CreateSwapChain(device, &swapchainDesc, &buffer.swapChain)))
	{
		return -1;
	}

	ID3D11Texture2D *backbuffer;
	buffer.swapChain->GetBuffer(0, __uuidof(ID3D11Texture2D), reinterpret_cast<void**>(&backbuffer));

	if (FAILED(device->CreateRenderTargetView(backbuffer, nullptr, &buffer.renderTarget)))
	{
		buffer.swapChain->Release();
		return -1;
	}

	renderBuffers[assignedId] = buffer;
	return assignedId;
}

void Renderer::DestroyRenderBuffer(int32_t bufferId)
{

}

void Renderer::Resize(int32_t bufferId, uint32_t width, uint32_t height)
{
	if (renderBuffers.count(bufferId) != 1) return;
	RenderBuffer buffer = renderBuffers[bufferId];

	buffer.swapChain->ResizeBuffers(0, 0, 0, DXGI_FORMAT_UNKNOWN, 0);

	ID3D11Texture2D *backbuffer;
	buffer.swapChain->GetBuffer(0, __uuidof(ID3D11Texture2D), reinterpret_cast<void**>(&backbuffer));

	device->CreateRenderTargetView(backbuffer, nullptr, &buffer.renderTarget);
}

void Renderer::SetRenderBuffer(int32_t bufferId)
{
	if (renderBuffers.count(bufferId) != 1) return;
	RenderBuffer buffer = renderBuffers[bufferId];

	deviceContext->OMSetRenderTargets(1, &buffer.renderTarget, nullptr);
	deviceContext->RSSetViewports(1, &buffer.viewport);

	float clearColor[] = { 1, 0, 0, 1 };
	deviceContext->ClearRenderTargetView(buffer.renderTarget, clearColor);

	buffer.swapChain->Present(0, DXGI_PRESENT_DO_NOT_WAIT);
}
