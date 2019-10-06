#pragma once

#include <Windows.h>
#include <wrl.h>

#include <d3d11.h>
#include <dxgi.h>

#include "DunCraw.h"
#include "DunDef.h"
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

		bool LoadShaders(IResourceManager &resMan) override;

		bool LoadTexture(const std::byte *data, size_t size, const Index &index) override;
		bool LoadModel(const std::byte *data, size_t size, const Index &index) override;

		void UnloadTexture(const Index &index) override;
		void UnloadModel(const Index &index) override;

	private:
		void OnResize(EventData data);
		void OnWindowChange(EventData data);

	private:
		Microsoft::WRL::ComPtr<ID3D11Device> device;
		Microsoft::WRL::ComPtr<ID3D11DeviceContext> context;

		Microsoft::WRL::ComPtr<IDXGISwapChain> swapchain;
		Microsoft::WRL::ComPtr<ID3D11RenderTargetView> renderTargetView;
		Microsoft::WRL::ComPtr<ID3D11DepthStencilView> depthStencilView;

		std::map<Index, Microsoft::WRL::ComPtr<ID3D11ShaderResourceView>> textures;

		Microsoft::WRL::ComPtr<ID3D11InputLayout> uiLayout;
		Microsoft::WRL::ComPtr<ID3D11VertexShader> uiVertexShader;
		Microsoft::WRL::ComPtr<ID3D11PixelShader> uiElementShader;
		Microsoft::WRL::ComPtr<ID3D11PixelShader> uiTextShader;

		bool windowVisible;

		int width, height;

		const HWND hWnd;

		bool initialized;
		Config &config;
		EventEngine &eventEngine;

		const SystemLocator &systems;

	};
}
