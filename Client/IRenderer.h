#pragma once

#include "DunDef.h"

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

	class IRenderer
	{
	public:
		virtual ~IRenderer() {}

		virtual bool Init() = 0;
		virtual void Destroy() = 0;

		virtual void Clear() = 0;
		virtual void Present() = 0;

		virtual bool LoadTexture(const uint8_t *data, size_t size, const Index &index) = 0;
		virtual bool LoadShader(const uint8_t *data, size_t size, ShaderType shaderType, const Index &index) = 0;
		virtual bool LoadModel(const uint8_t *data, size_t size, const Index &index) = 0;
	};
}
