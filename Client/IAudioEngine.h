#pragma once

namespace DunCraw
{
	class IAudioEngine
	{
	public:
		virtual ~IAudioEngine() {}
		virtual bool Init() = 0;
		virtual void Destroy() = 0;
	};
}