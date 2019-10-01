#pragma once

#include <Windows.h>
#include <wrl.h>

#include <d3d11.h>
#include <dxgi.h>

#include "DunCraw.h"
#include "IRenderer.h"

namespace DunCraw
{
	class DXRenderer : public IRenderer
	{
	public:
		DXRenderer(Config &config, EventEngine &eventEngine, const SystemLocator& systemLocator, const HWND hWnd);
		~DXRenderer();

		bool Init() override;
		void Destroy() override;

		void Clear() override;
		void Present() override;

		bool LoadTexture(const uint8_t *data, size_t size, int index) override;
		bool LoadShader(const uint8_t *data, size_t size, ShaderType shaderType, int index) override;
		bool LoadModel(const uint8_t *data, size_t size, int index) override;

	private:
		void OnResize(EventData data);
		void OnWindowChange(EventData data);

	private:
		Microsoft::WRL::ComPtr<ID3D11Device> device;
		Microsoft::WRL::ComPtr<ID3D11DeviceContext> context;

		Microsoft::WRL::ComPtr<IDXGISwapChain> swapchain;
		Microsoft::WRL::ComPtr<ID3D11RenderTargetView> renderTargetView;
		Microsoft::WRL::ComPtr<ID3D11DepthStencilView> depthStencilView;

		std::map<int, Microsoft::WRL::ComPtr<ID3D11ShaderResourceView>> textures;
		std::map<int, Microsoft::WRL::ComPtr<ID3D11VertexShader>> vertexShaders;
		std::map<int, Microsoft::WRL::ComPtr<ID3D11PixelShader>> pixelShaders;

		bool windowVisible;

		const HWND hWnd;

		bool initialized;
		Config &config;
		EventEngine &eventEngine;

		const SystemLocator &systems;

	};
}
