#pragma once

#include <Windows.h>

namespace DunCraw
{
	class Timer
	{
	public:
		Timer();
		~Timer();

		void Update();
		float Delta() const;
		float Total() const;

	private:
		double frequency, startTime, prevTime, curTime;

	};
}
