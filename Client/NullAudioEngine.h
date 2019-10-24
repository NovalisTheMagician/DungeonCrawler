#pragma once

#include "IAudioEngine.h"

namespace DunCraw
{
	class NullAudioEngine : public IAudioEngine
	{
	public:
		bool LoadSound(const std::byte *data, size_t size, const Index &index) override { return false; };
		void UnloadSound(const Index &index) override { };
	};
}
