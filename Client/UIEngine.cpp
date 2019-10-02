#include "UIEngine.h"

#include <rapidjson\rapidjson.h>

using std::placeholders::_1;

namespace DunCraw
{
	UIEngine::UIEngine(Config &config, EventEngine &eventEngine, const SystemLocator &systemLocator)
		: config(config), eventEngine(eventEngine), systems(systemLocator)
	{
	}

	UIEngine::~UIEngine()
	{
		Destroy();
	}

	Index meow;

	bool UIEngine::Init()
	{
		eventEngine.RegisterCallback(EV_CHAR, std::bind(&UIEngine::OnChar, this, _1));
		eventEngine.RegisterCallback(EV_MOUSEMOVEABS, std::bind(&UIEngine::OnMouseMove, this, _1));
		eventEngine.RegisterCallback(EV_MOUSEDOWN, std::bind(&UIEngine::OnMouseDown, this, _1));
		eventEngine.RegisterCallback(EV_MOUSEUP, std::bind(&UIEngine::OnMouseUp, this, _1));
		eventEngine.RegisterCallback(EV_MOUSEWHEEL, std::bind(&UIEngine::OnMouseWheel, this, _1));

		meow = systems.GetResourceManager().LoadAsset(AT_SOUND, "meow.wav");
		systems.GetResourceManager().UnloadAsset(meow);

		return true;
	}

	void UIEngine::Destroy()
	{

	}

	void UIEngine::Draw()
	{

	}

	void UIEngine::OnChar(EventData data)
	{
		char str[2] = { static_cast<char>(data.A), '\0' };
		OutputDebugStringA(str);

		eventEngine.SendEvent(EV_PLAYSOUND, { meow, 0, 0, nullptr });
	}

	void UIEngine::OnMouseMove(EventData data)
	{

	}

	void UIEngine::OnMouseDown(EventData data)
	{

	}

	void UIEngine::OnMouseUp(EventData data)
	{

	}

	void UIEngine::OnMouseWheel(EventData data)
	{

	}
}
