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
	};
}
