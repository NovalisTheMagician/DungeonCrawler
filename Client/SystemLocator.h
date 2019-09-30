#pragma once

#include "DunCraw.h"

#include "IWindow.h"
#include "IRenderer.h"
#include "IAudioEngine.h"
#include "IResourceManager.h"
#include "IScriptEngine.h"

#include "NullRenderer.h"
#include "NullAudioEngine.h"
#include "NullWindow.h"
#include "NullResourceManager.h"
#include "NullScriptEngine.h"

namespace DunCraw
{
	class SystemLocator
	{
	public:
		SystemLocator();

		IRenderer& GetRenderer() const;
		IAudioEngine& GetAudioEngine() const;
		IWindow& GetWindow() const;
		IResourceManager& GetResourceManager() const;
		IScriptEngine& GetScriptEngine() const;

		void Provide(IRenderer *renderer);
		void Provide(IAudioEngine *audioEngine);
		void Provide(IWindow *window);
		void Provide(IResourceManager *resourceManager);
		void Provide(IScriptEngine *scriptEngine);

	private:
		IRenderer *renderer;
		IAudioEngine *audioEngine;
		IWindow *window;
		IResourceManager *resourceManager;
		IScriptEngine *scriptEngine;

		std::unique_ptr<NullRenderer> nullRenderer;
		std::unique_ptr<NullAudioEngine> nullAudioEngine;
		std::unique_ptr<NullWindow> nullWindow;
		std::unique_ptr<NullResourceManager> nullResourceManager;
		std::unique_ptr<NullScriptEngine> nullScriptEngine;

	};
}
