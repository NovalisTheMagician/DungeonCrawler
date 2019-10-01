#include "DXRenderer.h"

#include <DirectXColors.h>
#include <DirectXMath.h>
#include "DDSTextureLoader.h"

#include <dxgi.h>

#pragma comment(lib, "d3d11.lib")
#pragma comment(lib, "dxgi.lib")
#pragma comment(lib, "dxguid.lib")

#include "Log.h"

using Microsoft::WRL::ComPtr;

using std::placeholders::_1;

namespace DunCraw
{
	DXRenderer::DXRenderer(Config &config, EventEngine &eventEngine, const SystemLocator& systemLocator, const HWND hWnd)
		: config(config), eventEngine(eventEngine), hWnd(hWnd), initialized(false), systems(systemLocator), windowVisible(true)
	{
	}

	DXRenderer::~DXRenderer()
	{
		Destroy();
	}

	bool DXRenderer::Init()
	{
		int width = config.GetInt("r_width", 800);
		int height = config.GetInt("r_height", 600);

		DXGI_SWAP_CHAIN_DESC swapchainDesc = { 0 };
		swapchainDesc.BufferDesc.Width = width;
		swapchainDesc.BufferDesc.Height = height;
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

		bool successRemoveAE = false;
		ComPtr<IDXGIDevice1> dxgiDevice;
		if (SUCCEEDED(device.As(&dxgiDevice)))
		{
			ComPtr<IDXGIAdapter> dxgiAdapter;
			if (SUCCEEDED(dxgiDevice->GetAdapter(dxgiAdapter.GetAddressOf())))
			{
				ComPtr<IDXGIFactory1> dxgiFactory;
				if (SUCCEEDED(dxgiAdapter->GetParent(__uuidof(IDXGIFactory1), &dxgiFactory)))
				{
					if (SUCCEEDED(dxgiFactory->MakeWindowAssociation(hWnd, DXGI_MWA_NO_ALT_ENTER)))
						successRemoveAE = true;
				}
			}
		}
		if (!successRemoveAE)
		{
			Log::Warning("Failed to remove Alt-Enter window association! Alt-Enter may result in unexpected outcome");
		}

		OnResize({ width, height, 0, nullptr });

		eventEngine.RegisterCallback(EV_RESIZE, std::bind(&DXRenderer::OnResize, this, _1));
		eventEngine.RegisterCallback(EV_WINDOWCHANGE, std::bind(&DXRenderer::OnWindowChange, this, _1));

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
		if (!windowVisible) return;
		context->ClearRenderTargetView(renderTargetView.Get(), DirectX::Colors::CornflowerBlue);
		context->ClearDepthStencilView(depthStencilView.Get(), D3D11_CLEAR_DEPTH | D3D11_CLEAR_STENCIL, 1.0f, 0);
	}

	void DXRenderer::Present()
	{
		if (!windowVisible) return;
		swapchain->Present(1, 0);
	}

	void DXRenderer::OnResize(EventData data)
	{
		if (!windowVisible) return;

		int width = data.A;
		int height = data.B;

		context->ClearState();
		depthStencilView.Reset();
		renderTargetView.Reset();

		swapchain->ResizeBuffers(0, width, height, DXGI_FORMAT_UNKNOWN, 0);
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

	void DXRenderer::OnWindowChange(EventData data)
	{
		windowVisible = data.A;
	}
}
