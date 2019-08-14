#include "Timer.h"

namespace DunCraw
{
	Timer::Timer()
		: frequency(), startTime(), prevTime(), curTime()
	{
		LARGE_INTEGER freq;
		QueryPerformanceFrequency(&freq);
		frequency = static_cast<double>(freq.QuadPart);

		LARGE_INTEGER counter;
		QueryPerformanceCounter(&counter);
		startTime = static_cast<double>(counter.QuadPart) / frequency;
		prevTime = curTime = startTime;
	}

	Timer::~Timer()
	{

	}

	void Timer::Update()
	{
		LARGE_INTEGER counter;
		QueryPerformanceCounter(&counter);
		prevTime = curTime;
		curTime = static_cast<double>(counter.QuadPart) / frequency;
	}

	float Timer::Delta() const
	{
		return static_cast<float>(curTime - prevTime);
	}

	float Timer::Total() const
	{
		return static_cast<float>(curTime - startTime);
	}
}
