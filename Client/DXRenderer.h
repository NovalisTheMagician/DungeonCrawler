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
	private:
		class DXSpriteBatch : public ISpriteBatch
		{
		public:
			DXSpriteBatch(DXRenderer &renderer);
			~DXSpriteBatch();

			Index CreateBuffer() override;
			void AddRect(const Index &bufId, std::array<UIVertex, 4> vertices) override;
			void FinalizeBuffer(const Index &bufId) override;

			void ClearState() override;

			void DrawBatch(const Index &bufid, const Index &texIndex, DirectX::XMFLOAT2 position) override;
			void DrawString(const Index &bufid, const Index &texIndex, DirectX::XMFLOAT2 position) override;

		private:
			DXRenderer &renderer;

			std::map<Index, std::vector<UIVertex>> vertices;
			std::map<Index, Microsoft::WRL::ComPtr<ID3D11Buffer>> buffers;

			Index curId;

		};

	public:
		DXRenderer(Config &config, EventEngine &eventEngine, const SystemLocator& systemLocator, const HWND hWnd);
		~DXRenderer();

		bool Init() override;
		void Destroy() override;

		void Clear() override;
		void Present() override;

		ISpriteBatch *CreateSpriteBatch() override;

		bool LoadShaders(IResourceManager &resMan) override;

		bool LoadTexture(const std::byte *data, size_t size, const Index &index) override;
		bool LoadModel(const std::byte *data, size_t size, const Index &index) override;

		void UnloadTexture(const Index &index) override;
		void UnloadModel(const Index &index) override;

	private:
		void OnResize(EventData &data);
		void OnWindowChange(EventData &data);

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

		Microsoft::WRL::ComPtr<ID3D11SamplerState> uiSampler;

		std::unique_ptr<DXSpriteBatch> spriteBatch;

		bool windowVisible;

		int width, height;

		const HWND hWnd;

		bool initialized;
		Config &config;
		EventEngine &eventEngine;

		const SystemLocator &systems;

		friend DXSpriteBatch;

	};
}
