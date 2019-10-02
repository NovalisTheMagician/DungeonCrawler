#pragma once

#include <stdint.h>
#include "DunDef.h"

namespace DunCraw
{
	class IAudioEngine
	{
	public:
		virtual ~IAudioEngine() {}
		virtual bool Init() = 0;
		virtual void Destroy() = 0;

		virtual bool LoadSound(const uint8_t *data, size_t size, const Index &index) = 0;
	};
}