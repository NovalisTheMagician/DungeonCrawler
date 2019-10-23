#include "DXRenderer.h"

#include <DirectXColors.h>
#include <DirectXMath.h>
#include "DDSTextureLoader.h"

#include <dxgi.h>

#pragma comment(lib, "d3d11.lib")
#pragma comment(lib, "dxgi.lib")
#pragma comment(lib, "dxguid.lib")

#include "Log.h"

using std::optional;
using std::vector;

using Microsoft::WRL::ComPtr;

using std::placeholders::_1;

using namespace DirectX;

namespace DunCraw
{
	struct UITransform
	{
		float viewWidth;
		float viewHeight;
		XMFLOAT2 elemPosition;
		XMFLOAT4 tint;
	};

	DXRenderer::DXSpriteBatch::DXSpriteBatch(DXRenderer &renderer)
		: renderer(renderer), curId(0), projection()
	{
		D3D11_BUFFER_DESC bufferDesc;
		bufferDesc.Usage = D3D11_USAGE_DYNAMIC;
		bufferDesc.ByteWidth = sizeof(UITransform);
		bufferDesc.BindFlags = D3D11_BIND_CONSTANT_BUFFER;
		bufferDesc.CPUAccessFlags = D3D11_CPU_ACCESS_WRITE;
		bufferDesc.MiscFlags = 0;

		if (FAILED(renderer.device->CreateBuffer(&bufferDesc, nullptr, &transformBuffer)))
		{
			throw new std::exception("Failed to init constantbuffer");
		}
	}

	DXRenderer::DXSpriteBatch::~DXSpriteBatch()
	{
		std::for_each(buffers.begin(), buffers.end(), [](auto &elem) { elem.second.Reset(); });
		transformBuffer.Reset();
	}

	Index DXRenderer::DXSpriteBatch::CreateBuffer()
	{
		Index id = curId++;
		vertices[id];

		return id;
	}

	void DXRenderer::DXSpriteBatch::AddRect(const Index &bufId, std::array<UIVertex, 4> verts)
	{
		if (vertices.count(bufId) > 0)
		{
			vector<UIVertex> &vertList = vertices.at(bufId);
			vertList.push_back(verts[3]);
			vertList.push_back(verts[1]);
			vertList.push_back(verts[0]);

			vertList.push_back(verts[1]);
			vertList.push_back(verts[3]);
			vertList.push_back(verts[2]);
		}
	}

	void DXRenderer::DXSpriteBatch::FinalizeBuffer(const Index &bufId)
	{
		if (vertices.count(bufId) > 0)
		{
			vector<UIVertex> &vertList = vertices.at(bufId);

			D3D11_BUFFER_DESC bufferDesc;
			bufferDesc.Usage = D3D11_USAGE_DEFAULT;
			bufferDesc.ByteWidth = sizeof(UIVertex) * vertList.size();
			bufferDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
			bufferDesc.CPUAccessFlags = 0;
			bufferDesc.MiscFlags = 0;

			D3D11_SUBRESOURCE_DATA initData;
			initData.pSysMem = vertList.data();
			initData.SysMemPitch = 0;
			initData.SysMemSlicePitch = 0;

			ComPtr<ID3D11Buffer> &buffer = buffers[bufId];

			if (FAILED(renderer.device->CreateBuffer(&bufferDesc, &initData, buffer.ReleaseAndGetAddressOf())))
			{
				Log::Error("Failed to create a vertexbuffer for bufferID = " + std::to_string(bufId));
			}
		}
	}

	void DXRenderer::DXSpriteBatch::ClearState()
	{

	}

	void DXRenderer::DXSpriteBatch::BeginDraw()
	{
		XMMATRIX projMat = XMMatrixOrthographicLH(renderer.width, renderer.height, 0.1f, 100.0f);
		XMStoreFloat4x4(&projection, projMat);
	}

	void DXRenderer::DXSpriteBatch::EndDraw()
	{

	}

	void DXRenderer::DXSpriteBatch::UpdateTransform(DirectX::XMFLOAT2 position, DirectX::XMFLOAT4 tint)
	{
		UITransform transform;
		transform.viewWidth = renderer.width;
		transform.viewHeight = renderer.height;
		transform.elemPosition = position;
		transform.tint = tint;

		D3D11_MAPPED_SUBRESOURCE subresource = { 0 };
		renderer.context->Map(transformBuffer.Get(), 0, D3D11_MAP_WRITE_DISCARD, 0, &subresource);
		memcpy(subresource.pData, &transform, sizeof transform);
		renderer.context->Unmap(transformBuffer.Get(), 0);
	}

	void DXRenderer::DXSpriteBatch::DrawBatch(const Index &bufId, const Index &texIndex, DirectX::XMFLOAT2 position, DirectX::XMFLOAT4 tint)
	{
		ComPtr<ID3D11DeviceContext> &context = renderer.context;
		if (buffers.count(bufId) > 0 && renderer.textures.count(texIndex) > 0)
		{
			UpdateTransform(position, tint);

			ComPtr<ID3D11Buffer> &buffer = buffers.at(bufId);
			uint32_t stride = sizeof(UIVertex);
			uint32_t offset = 0;

			context->VSSetShader(renderer.uiVertexShader.Get(), nullptr, 0);
			context->PSSetShader(renderer.uiElementShader.Get(), nullptr, 0);

			context->IASetVertexBuffers(0, 1, buffer.GetAddressOf(), &stride, &offset);
			context->IASetInputLayout(renderer.uiLayout.Get());
			context->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);

			context->VSSetConstantBuffers(0, 1, transformBuffer.GetAddressOf());
			context->PSSetConstantBuffers(0, 1, transformBuffer.GetAddressOf());

			auto &texture = renderer.textures.at(texIndex);
			context->PSSetShaderResources(0, 1, texture.GetAddressOf());
			context->PSSetSamplers(0, 1, renderer.uiSampler.GetAddressOf());

			uint32_t vertCount = vertices.at(bufId).size();
			context->Draw(vertCount, 0);
		}
	}

	void DXRenderer::DXSpriteBatch::DrawString(const Index &bufid, const Index &texIndex, DirectX::XMFLOAT2 position, DirectX::XMFLOAT4 tint)
	{

	}



	DXRenderer::DXRenderer(Config &config, EventEngine &eventEngine, const SystemLocator& systemLocator, const HWND hWnd)
		: config(config), eventEngine(eventEngine), hWnd(hWnd), initialized(false), systems(systemLocator), 
			windowVisible(true), textures(), width(0), height(0)
	{
	}

	DXRenderer::~DXRenderer()
	{
		Destroy();
	}

	bool DXRenderer::Init()
	{
		width = config.GetInt("r_width", 800);
		height = config.GetInt("r_height", 600);

		DXGI_SWAP_CHAIN_DESC swapchainDesc = { 0 };
		swapchainDesc.BufferDesc.Width = width;
		swapchainDesc.BufferDesc.Height = height;
		swapchainDesc.BufferDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM_SRGB;
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
			Log::Warning("Failed to remove Alt-Enter window association! Alt-Enter may result in unexpected behaviour");
		}

		D3D11_SAMPLER_DESC samplerDesc;
		samplerDesc.Filter = D3D11_FILTER_MIN_MAG_MIP_LINEAR;
		samplerDesc.AddressU = D3D11_TEXTURE_ADDRESS_WRAP;
		samplerDesc.AddressV = D3D11_TEXTURE_ADDRESS_WRAP;
		samplerDesc.AddressW = D3D11_TEXTURE_ADDRESS_WRAP;
		samplerDesc.BorderColor[0] = 1.0f;
		samplerDesc.BorderColor[1] = 1.0f;
		samplerDesc.BorderColor[2] = 1.0f;
		samplerDesc.BorderColor[3] = 1.0f;
		samplerDesc.MipLODBias = 0;
		samplerDesc.MaxAnisotropy = 1;
		samplerDesc.ComparisonFunc = D3D11_COMPARISON_NEVER;
		samplerDesc.MinLOD = 0;
		samplerDesc.MaxLOD = D3D11_FLOAT32_MAX;
		if (FAILED(device->CreateSamplerState(&samplerDesc, &uiSampler)))
		{
			Log::Error("Failed to create SamplerState for UI");
			return false;
		}

		EventData data;
		data.SetA(width);
		data.SetB(height);
		OnResize(data);

		eventEngine.RegisterCallback(EV_RESIZE, std::bind(&DXRenderer::OnResize, this, _1));
		eventEngine.RegisterCallback(EV_WINDOWCHANGE, std::bind(&DXRenderer::OnWindowChange, this, _1));

		initialized = true;
		return true;
	}

	void DXRenderer::Destroy()
	{
		if (!initialized)
			return;

		spriteBatch.reset();

		uiSampler.Reset();

		textures.clear();

		uiVertexShader.Reset();
		uiElementShader.Reset();
		uiTextShader.Reset();

		uiLayout.Reset();

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

	ISpriteBatch *DXRenderer::CreateSpriteBatch()
	{
		if (!spriteBatch)
		{
			spriteBatch.reset(new DXSpriteBatch(*this));
		}
		return spriteBatch.get();
	}

	void DXRenderer::Clear()
	{
		if (!windowVisible) return;
		const float *clearColor = DirectX::Colors::CornflowerBlue;

#ifdef _DEBUG
		clearColor = DirectX::Colors::Magenta;
#endif

		context->ClearRenderTargetView(renderTargetView.Get(), clearColor);
		context->ClearDepthStencilView(depthStencilView.Get(), D3D11_CLEAR_DEPTH | D3D11_CLEAR_STENCIL, 1.0f, 0);
	}

	void DXRenderer::Present()
	{
		if (!windowVisible) return;
		HRESULT hr = swapchain->Present(1, 0);
		if (hr == DXGI_ERROR_DEVICE_REMOVED)
		{
			Log::Error("Uh oh! Graphics device removed! (Either through driver upgrade or physically removed)");
		}
	}

	bool DXRenderer::LoadShaders(IResourceManager &resMan)
	{
		Index id = resMan.LoadAsset(AssetType::SHADER, "UI_VS.cso");
		if (id == InvalidIndex) return false;
		size_t size;
		std::byte *data = resMan.GetAssetData(id, &size);
		if (FAILED(device->CreateVertexShader(data, size, nullptr, &uiVertexShader)))
		{
			return false;
		}

		D3D11_INPUT_ELEMENT_DESC uiInputLayoutDesc[] =
		{
			{ "POSITION",	0, DXGI_FORMAT_R32G32_FLOAT,		0, D3D11_APPEND_ALIGNED_ELEMENT, D3D11_INPUT_PER_VERTEX_DATA, 0 },
			{ "TEXCOORD",	0, DXGI_FORMAT_R32G32_FLOAT,		0, D3D11_APPEND_ALIGNED_ELEMENT, D3D11_INPUT_PER_VERTEX_DATA, 0 },
			{ "COLOR",		0, DXGI_FORMAT_R32G32B32A32_FLOAT,	0, D3D11_APPEND_ALIGNED_ELEMENT, D3D11_INPUT_PER_VERTEX_DATA, 0 }
		};

		if (FAILED(device->CreateInputLayout(uiInputLayoutDesc, _countof(uiInputLayoutDesc), data, size, &uiLayout)))
		{
			return false;
		}

		resMan.UnloadAsset(id);
		id = resMan.LoadAsset(AssetType::SHADER, "UIElement_PS.cso");
		if (id == InvalidIndex) return false;
		data = resMan.GetAssetData(id, &size);

		if (FAILED(device->CreatePixelShader(data, size, nullptr, &uiElementShader)))
		{
			return false;
		}

		resMan.UnloadAsset(id);
		id = resMan.LoadAsset(AssetType::SHADER, "UIText_PS.cso");
		if (id == InvalidIndex) return false;
		data = resMan.GetAssetData(id, &size);

		if (FAILED(device->CreatePixelShader(data, size, nullptr, &uiTextShader)))
		{
			return false;
		}
		resMan.UnloadAsset(id);

		return true;
	}

	bool DXRenderer::LoadTexture(const std::byte *data, size_t size, const Index &index)
	{
		ComPtr<ID3D11ShaderResourceView> texture;
		HRESULT hr = DirectX::CreateDDSTextureFromMemory(device.Get(), reinterpret_cast<const uint8_t*>(data), size, nullptr, &texture);
		if (SUCCEEDED(hr))
		{
			textures.emplace(index, std::move(texture));
			return true;
		}
		return false;
	}

	bool DXRenderer::LoadModel(const std::byte *data, size_t size, const Index &index)
	{
		return false;
	}

	void DXRenderer::UnloadTexture(const Index &index)
	{
		textures.erase(index);
	}

	void DXRenderer::UnloadModel(const Index &index)
	{

	}

	void DXRenderer::OnResize(EventData &data)
	{
		if (!windowVisible) return;

		width = data.GetA<int>();
		height = data.GetB<int>();

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

	void DXRenderer::OnWindowChange(EventData &data)
	{
		windowVisible = data.GetA<bool>();
	}
}
