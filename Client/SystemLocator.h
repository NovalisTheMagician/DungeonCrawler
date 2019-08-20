#pragma once

#include "DunCraw.h"

#include "IWindow.h"
#include "IRenderer.h"
#include "IAudioEngine.h"
#include "IResourceManager.h"

namespace DunCraw
{
	class SystemLocator
	{
	public:
		IRenderer& GetRenderer() const;
		IAudioEngine& GetAudioEngine() const;
		IWindow& GetWindow() const;
		IResourceManager& GetResourceManager() const;
	};
}
