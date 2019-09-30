#pragma once

#include "IAudioEngine.h"

namespace DunCraw
{
	class NullAudioEngine : public IAudioEngine
	{
	public:
		bool Init() override { return true; };
		void Destroy() override { };
	};
}
