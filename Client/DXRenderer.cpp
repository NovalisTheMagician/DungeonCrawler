#include "DXRenderer.h"

#include <DirectXColors.h>
#include <DirectXMath.h>

#pragma comment(lib, "d3d11.lib")
#pragma comment(lib, "dxgi.lib")

#include "Log.h"

using Microsoft::WRL::ComPtr;

namespace DunCraw
{
	DXRenderer::DXRenderer(Config &config, const HWND hWnd)
		: device(), context(), config(config), hWnd(hWnd),
			renderTargetView(), depthStencilView(), swapchain(),
			initialized(false)
	{

	}

	DXRenderer::~DXRenderer()
	{
		Destroy();
	}

	bool DXRenderer::Init()
	{
		DXGI_SWAP_CHAIN_DESC swapchainDesc = { 0 };
		swapchainDesc.BufferDesc.Width = 0;
		swapchainDesc.BufferDesc.Height = 0;
		swapchainDesc.BufferDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
		swapchainDesc.BufferDesc.RefreshRate.Numerator = 60;
		swapchainDesc.BufferDesc.RefreshRate.Denominator = 1;
		swapchainDesc.BufferCount = 1;
		swapchainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
		swapchainDesc.OutputWindow = hWnd;
		swapchainDesc.Windowed = true;
		swapchainDesc.SampleDesc.Count = 1;
		swapchainDesc.SampleDesc.Quality = 0;

		D3D_FEATURE_LEVEL featureLevelReq = D3D_FEATURE_LEVEL_11_0;
		int numFeatureLevels = 1;
		D3D_FEATURE_LEVEL featureLevelSupported;

		UINT flags = 0;
#ifdef _DEBUG
		flags |= D3D11_CREATE_DEVICE_DEBUG;
#endif

		if (FAILED(D3D11CreateDeviceAndSwapChain(nullptr, D3D_DRIVER_TYPE_HARDWARE, nullptr, flags, &featureLevelReq, numFeatureLevels, D3D11_SDK_VERSION, &swapchainDesc, swapchain.ReleaseAndGetAddressOf(), device.ReleaseAndGetAddressOf(), &featureLevelSupported, context.ReleaseAndGetAddressOf())))
		{
			Log::Error("Failed to create D3D11 device!");
			return false;
		}

		Resize();

		initialized = true;
		return true;
	}

	void DXRenderer::Destroy()
	{
		if (!initialized)
			return;

		renderTargetView.Reset();
		depthStencilView.Reset();
		swapchain.Reset();
		context.Reset();

#ifdef _DEBUG
		ComPtr<ID3D11Debug> debug;
		if (SUCCEEDED(device.As(&debug)))
		{
			debug->ReportLiveDeviceObjects(D3D11_RLDO_DETAIL);
		}
#endif
		device.Reset();

		initialized = false;
	}

	void DXRenderer::Clear()
	{
		context->ClearRenderTargetView(renderTargetView.Get(), DirectX::Colors::CornflowerBlue);
		context->ClearDepthStencilView(depthStencilView.Get(), D3D11_CLEAR_DEPTH | D3D11_CLEAR_STENCIL, 1.0f, 0);
	}

	void DXRenderer::Present()
	{
		swapchain->Present(1, 0);
	}

	void DXRenderer::Resize()
	{
		int width = config.GetInt("r_width", 800);
		int height = config.GetInt("r_height", 600);

		context->ClearState();
		depthStencilView.Reset();
		renderTargetView.Reset();

		swapchain->ResizeBuffers(0, 0, 0, DXGI_FORMAT_UNKNOWN, 0);
		ComPtr<ID3D11Texture2D> backbuffer;
		swapchain->GetBuffer(0, __uuidof(ID3D11Texture2D), reinterpret_cast<void**>(backbuffer.GetAddressOf()));
		device->CreateRenderTargetView(backbuffer.Get(), nullptr, renderTargetView.GetAddressOf());

		D3D11_TEXTURE2D_DESC depthStencilDesc = { 0 };
		depthStencilDesc.ArraySize = 1;
		depthStencilDesc.Width = width;
		depthStencilDesc.Height = height;
		depthStencilDesc.Format = DXGI_FORMAT_D24_UNORM_S8_UINT;
		depthStencilDesc.BindFlags = D3D11_BIND_DEPTH_STENCIL;
		depthStencilDesc.SampleDesc.Count = 1;
		depthStencilDesc.SampleDesc.Quality = 0;
		depthStencilDesc.Usage = D3D11_USAGE_DEFAULT;

		ComPtr<ID3D11Texture2D> depthStencilTexture;
		device->CreateTexture2D(&depthStencilDesc, nullptr, depthStencilTexture.GetAddressOf());
		device->CreateDepthStencilView(depthStencilTexture.Get(), nullptr, depthStencilView.GetAddressOf());

		D3D11_VIEWPORT viewport;
		viewport.Width = static_cast<float>(width);
		viewport.Height = static_cast<float>(height);
		viewport.TopLeftX = 0;
		viewport.TopLeftY = 0;
		viewport.MinDepth = 0;
		viewport.MaxDepth = 1;

		context->OMSetRenderTargets(1, renderTargetView.GetAddressOf(), depthStencilView.Get());
		context->RSSetViewports(1, &viewport);
	}
}
