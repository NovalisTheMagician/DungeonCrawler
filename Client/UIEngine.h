#pragma once

#include "DunCraw.h"

#include "IRenderer.h"

namespace DunCraw
{
	class UIEngine
	{
	public:
		UIEngine(Config &config, EventEngine &eventEngine, IRenderer &renderer);
		~UIEngine();

		UIEngine(const UIEngine &uiengine) = delete;
		UIEngine& operator=(const UIEngine &uiengine) = delete;

		bool Init();
		void Destroy();

		void Draw();

	private:
		IRenderer &renderer;

		Config &config;
		EventEngine &eventEngine;

	};
}
