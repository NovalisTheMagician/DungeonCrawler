#pragma once

#include "IRenderer.h"

namespace DunCraw
{
	class NullRenderer : public IRenderer
	{
	public:
		bool Init() override { return true; };
		void Destroy() override { };

		void Clear() override { };
		void Present() override { };

		bool LoadTexture(const uint8_t *data, size_t size, int index) override { return false; };
		bool LoadShader(const uint8_t *data, size_t size, ShaderType shaderType, int index) override { return false; };
		bool LoadModel(const uint8_t *data, size_t size, int index) override { return false; };
	};
}
