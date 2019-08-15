#pragma once

#include <Windows.h>
#include <wrl.h>

#include <d3d11.h>
#include <dxgi.h>

#include "Config.h"
#include "EventEngine.h"
#include "IRenderer.h"

namespace DunCraw
{
	class DXRenderer : public IRenderer
	{
	public:
		DXRenderer(Config &config, EventEngine &eventEngine, const HWND hWnd);
		~DXRenderer();

		bool Init() override;
		void Destroy() override;

		void Clear() override;
		void Present() override;

	private:
		void OnResize(EventData data);

	private:
		Microsoft::WRL::ComPtr<ID3D11Device> device;
		Microsoft::WRL::ComPtr<ID3D11DeviceContext> context;

		Microsoft::WRL::ComPtr<IDXGISwapChain> swapchain;
		Microsoft::WRL::ComPtr<ID3D11RenderTargetView> renderTargetView;
		Microsoft::WRL::ComPtr<ID3D11DepthStencilView> depthStencilView;

		const HWND hWnd;

		bool initialized;
		Config &config;
		EventEngine &eventEngine;

	};
}
