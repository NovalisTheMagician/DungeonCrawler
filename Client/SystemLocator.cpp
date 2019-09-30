#include "SystemLocator.h"

namespace DunCraw
{
	SystemLocator::SystemLocator()
		: nullRenderer(new NullRenderer), nullAudioEngine(new NullAudioEngine), nullWindow(new NullWindow), 
		nullResourceManager(new NullResourceManager), nullScriptEngine(new NullScriptEngine)
	{
		renderer = nullRenderer.get();
		audioEngine = nullAudioEngine.get();
		window = nullWindow.get();
		resourceManager = nullResourceManager.get();
		scriptEngine = nullScriptEngine.get();
	}

	IRenderer& SystemLocator::GetRenderer() const
	{
		return *renderer;
	}

	IAudioEngine& SystemLocator::GetAudioEngine() const
	{
		return *audioEngine;
	}

	IWindow& SystemLocator::GetWindow() const
	{
		return *window;
	}

	IResourceManager& SystemLocator::GetResourceManager() const
	{
		return *resourceManager;
	}

	IScriptEngine& SystemLocator::GetScriptEngine() const
	{
		return *scriptEngine;
	}

	void SystemLocator::Provide(IRenderer *renderer)
	{
		this->renderer = renderer;
	}

	void SystemLocator::Provide(IAudioEngine *audioEngine)
	{
		this->audioEngine = audioEngine;
	}

	void SystemLocator::Provide(IWindow *window)
	{
		this->window = window;
	}

	void SystemLocator::Provide(IResourceManager *resourceManager)
	{
		this->resourceManager = resourceManager;
	}

	void SystemLocator::Provide(IScriptEngine *scriptEngine)
	{
		this->scriptEngine = scriptEngine;
	}
}
