#pragma once

#include "IRenderer.h"

namespace DunCraw
{
	class NullRenderer : public IRenderer
	{
	public:
		void Clear() override { };
		void Present() override { };

		ISpriteBatch *CreateSpriteBatch() override { return nullptr; };

		bool LoadShaders(IResourceManager &resMan) override { return true; };

		bool LoadTexture(const std::byte *data, size_t size, const Index &index) override { return false; };
		bool LoadModel(const std::byte *data, size_t size, const Index &index) override { return false; };

		void UnloadTexture(const Index &index) override { };
		void UnloadModel(const Index &index) override { };
	};
}
