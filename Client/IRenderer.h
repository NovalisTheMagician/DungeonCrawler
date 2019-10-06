#pragma once

#include "DunDef.h"

#include <cstddef>

#include <DirectXMath.h>

#include "IResourceManager.h"

namespace DunCraw
{
	enum ShaderType
	{
		ST_VERTEX,
		ST_PIXEL,
		ST_GEOMETRY,
		ST_HULL,
		ST_DOMAIN
	};

	// TODO refactor to a more portable math type
	struct UIVertex
	{
		DirectX::XMFLOAT2 pos;
		DirectX::XMFLOAT2 tex;
	};

	class IRenderer
	{
	public:
		virtual ~IRenderer() {}

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
