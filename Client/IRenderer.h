#pragma once

#include "DunDef.h"

#include <cstddef>

#include <DirectXMath.h>

#include "IResourceManager.h"

#include "VertexDefs.h"

#include <functional>

namespace DunCraw
{
	class ISpriteBatch
	{
	public:
		virtual ~ISpriteBatch() {};

		virtual Index CreateBuffer() = 0;
		virtual void AddRect(const Index &bufId, std::array<UIVertex, 4> vertices) = 0;
		virtual void FinalizeBuffer(const Index &bufId) = 0;

		virtual void ClearState() = 0;

		virtual void BeginDraw() = 0;
		virtual void EndDraw() = 0;

		virtual void DrawBatch(const Index &bufid, const Index &texIndex, DirectX::XMFLOAT2 position, DirectX::XMFLOAT4 tint) = 0;
		virtual void DrawString(const Index &bufid, const Index &texIndex, DirectX::XMFLOAT2 position, DirectX::XMFLOAT4 tint) = 0;
	};

	class IRenderer
	{
	public:
		virtual ~IRenderer() {};

		virtual bool Init() = 0;
		virtual void Destroy() = 0;

		virtual ISpriteBatch *CreateSpriteBatch() = 0;

		virtual void Clear() = 0;
		virtual void Present() = 0;

		virtual bool LoadShaders(IResourceManager &resMan) = 0;

		virtual bool LoadTexture(const std::byte *data, size_t size, const Index &index) = 0;
		virtual bool LoadModel(const std::byte *data, size_t size, const Index &index) = 0;

		virtual void UnloadTexture(const Index &index) = 0;
		virtual void UnloadModel(const Index &index) = 0;
	};
}
