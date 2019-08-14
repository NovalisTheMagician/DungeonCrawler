#pragma once

#include <memory>

#include "IWindow.h"
#include "IRenderer.h"

#include "Config.h"

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
		void Update(float delta);
		void Draw();
		void Destroy();

	private:
		std::unique_ptr<IWindow> window;
		std::unique_ptr<IRenderer> renderer;

		Config &config;

	};
}
