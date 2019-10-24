#pragma once

#include <stdint.h>
#include "DunDef.h"

#include <cstddef>

namespace DunCraw
{
	class IAudioEngine
	{
	public:
		virtual ~IAudioEngine() {}

		virtual bool LoadSound(const std::byte *data, size_t size, const Index &index) = 0;
		virtual void UnloadSound(const Index &index) = 0;
	};
}