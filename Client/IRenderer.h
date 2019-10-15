#pragma once

#include "DunDef.h"

#include <cstddef>

#include <DirectXMath.h>

#include "IResourceManager.h"

#include "VertexDefs.h"

namespace DunCraw
{
	class ISpriteBatch
	{
	public:
		virtual ~ISpriteBatch() {};

		virtual void AddRect(std::array<UIVertex, 4> vertices) = 0;

		virtual void ClearState() = 0;

		virtual void DrawBatch(const Index &texIndex) = 0;
		virtual void DrawString(const Index &texIndex) = 0;
	};

	class IRenderer
	{
	public:
		virtual ~IRenderer() {};

		virtual bool Init() = 0;
		virtual void Destroy() = 0;

		virtual void Clear() = 0;
		virtual void Present() = 0;

		virtual bool LoadShaders(IResourceManager &resMan) = 0;

		virtual bool LoadTexture(const std::byte *data, size_t size, const Index &index) = 0;
		virtual bool LoadModel(const std::byte *data, size_t size, const Index &index) = 0;

		virtual void UnloadTexture(const Index &index) = 0;
		virtual void UnloadModel(const Index &index) = 0;
	};
}
