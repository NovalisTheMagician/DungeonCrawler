#pragma once

#include <memory>

#include "IWindow.h"
#include "IRenderer.h"
#include "IAudioEngine.h"

#include "Config.h"
#include "Timer.h"

namespace DunCraw
{
	class GameLoop
	{
	public:
		GameLoop(Config &config);
		~GameLoop();
		GameLoop(const GameLoop&) = delete;
		GameLoop& operator=(const GameLoop&) = delete;

		//void SetDefaultConfig();

		int Start();

	private:
		bool Initialize();
		void Update(const Timer &timer);
		void Draw();
		void Destroy();

	private:
		std::unique_ptr<IWindow> window;
		std::unique_ptr<IRenderer> renderer;
		std::unique_ptr<IAudioEngine> audioEngine;

		Config &config;

	};
}
