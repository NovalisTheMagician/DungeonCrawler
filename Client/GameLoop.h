#pragma once

#include "DunCraw.h"

#include "IWindow.h"
#include "IRenderer.h"
#include "IAudioEngine.h"
#include "IResourceManager.h"
#include "UIEngine.h"
#include "IScriptEngine.h"

#include "Args.h"

#include "SystemLocator.h"

namespace DunCraw
{
	class GameLoop
	{
	public:
		GameLoop(Config &config, const Args &args);
		~GameLoop();
		GameLoop(const GameLoop&) = delete;
		GameLoop& operator=(const GameLoop&) = delete;

		//void SetDefaultConfig();

		int Start();

	private:
		bool Initialize();
		bool InitSubsystems();

		void FixedUpdate(const Timer &timer);
		void Update(const Timer &timer);
		void Draw();
		void Destroy();

	private:
		std::unique_ptr<IWindow> window;
		std::unique_ptr<IRenderer> renderer;
		std::unique_ptr<IAudioEngine> audioEngine;
		std::unique_ptr<IResourceManager> resourceManager;
		std::unique_ptr<UIEngine> uiEngine;
		std::unique_ptr<IScriptEngine> scriptEngine;

		Config &config;
		EventEngine eventEngine;

		SystemLocator locator;

		const Args &args;

		static const float TARGET_DELTA;

		static const std::string &MAIN_ARCHIVE_FILE;
		static const std::string &ASSET_FILESYSTEM_PATH;

	};
}
