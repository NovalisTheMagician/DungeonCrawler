#include "renderer.h"

Renderer::Renderer()
	: device(nullptr), deviceContext(nullptr), initialized(false), renderBuffers()
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

	initialized = true;
	return true;
}

void Renderer::ReleaseDevice()
{
	deviceContext->Release();
	delete deviceContext;

	device->Release();
	delete device;
}

void Renderer::ReleaseBuffersAndSwapChains()
{

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
}
