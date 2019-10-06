#pragma once

#include "DunCraw.h"

#include "IRenderer.h"

namespace DunCraw
{
	class UIEngine
	{
	public:
		UIEngine(Config &config, EventEngine &eventEngine, const SystemLocator &systemLocator);
		~UIEngine();

		UIEngine(const UIEngine &uiengine) = delete;
		UIEngine& operator=(const UIEngine &uiengine) = delete;

		bool Init();
		void Destroy();

		void Draw();

	private:
		void OnChar(EventData data);
		void OnMouseMove(EventData data);
		void OnMouseDown(EventData data);
		void OnMouseUp(EventData data);
		void OnMouseWheel(EventData data);

		void OnWindowResize(EventData data);

	private:
		Config &config;
		EventEngine &eventEngine;
		const SystemLocator &systems;

	};
}
