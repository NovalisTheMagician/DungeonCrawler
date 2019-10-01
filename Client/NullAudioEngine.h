#pragma once

#include "IAudioEngine.h"

namespace DunCraw
{
	class NullAudioEngine : public IAudioEngine
	{
	public:
		bool Init() override { return true; };
		void Destroy() override { };

		bool LoadSound(const uint8_t *data, size_t size, const Index &index) override { return false; };
	};
}
