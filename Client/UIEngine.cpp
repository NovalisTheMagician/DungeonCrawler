#include "UIEngine.h"

#include <rapidjson\rapidjson.h>

using std::placeholders::_1;

using namespace DirectX;

using std::array;

namespace DunCraw
{
	Index meowSnd;
	Index meowImg;
	Index meowBuffer;

	UIEngine::UIEngine(Config &config, EventEngine &eventEngine, const SystemLocator &systemLocator)
		: config(config), eventEngine(eventEngine), systems(systemLocator), spriteBatch(nullptr)
	{
		spriteBatch = systems.GetRenderer().CreateSpriteBatch();
		if (!spriteBatch)
			throw GameSystemException("UIEngine");

		eventEngine.RegisterCallback(EV_CHAR, std::bind(&UIEngine::OnChar, this, _1));
		eventEngine.RegisterCallback(EV_MOUSEMOVEABS, std::bind(&UIEngine::OnMouseMove, this, _1));
		eventEngine.RegisterCallback(EV_MOUSEDOWN, std::bind(&UIEngine::OnMouseDown, this, _1));
		eventEngine.RegisterCallback(EV_MOUSEUP, std::bind(&UIEngine::OnMouseUp, this, _1));
		eventEngine.RegisterCallback(EV_MOUSEWHEEL, std::bind(&UIEngine::OnMouseWheel, this, _1));
		eventEngine.RegisterCallback(EV_RESIZE, std::bind(&UIEngine::OnWindowResize, this, _1));

		auto &resMan = systems.GetResourceManager();

		meowSnd = resMan.LoadAsset(AssetType::SOUND, "meow.wav");
		resMan.UnloadAsset(meowSnd);

		meowImg = resMan.LoadAsset(AssetType::TEXTURE, "meow.dds");
		resMan.UnloadAsset(meowImg);

		meowBuffer = spriteBatch->CreateBuffer();

		array<UIVertex, 4> vertices;
		vertices[0] = { XMFLOAT2(0, 0), XMFLOAT2(0, 0), XMFLOAT4(1, 1, 1, 1) };
		vertices[1] = { XMFLOAT2(512, 0), XMFLOAT2(1, 0), XMFLOAT4(1, 1, 1, 1) };
		vertices[2] = { XMFLOAT2(512, 512), XMFLOAT2(1, 1), XMFLOAT4(1, 1, 1, 1) };
		vertices[3] = { XMFLOAT2(0, 512), XMFLOAT2(0, 1), XMFLOAT4(1, 1, 1, 1) };

		spriteBatch->AddRect(meowBuffer, vertices);
		spriteBatch->FinalizeBuffer(meowBuffer);
	}

	UIEngine::~UIEngine()
	{
		
	}

	void UIEngine::Draw()
	{
		spriteBatch->DrawBatch(meowBuffer, meowImg, XMFLOAT2(0, 0), XMFLOAT4(1, 1, 1, 1));
	}

	void UIEngine::OnChar(EventData &data)
	{
		char str[2] = { data.GetA<char>(), '\0' };
		OutputDebugStringA(str);

		EventData &soundEvent = eventEngine.GetData();
		soundEvent.SetA(meowSnd);
		eventEngine.SendEvent(EV_PLAYSOUND, soundEvent);
	}

	void UIEngine::OnMouseMove(EventData &data)
	{

	}

	void UIEngine::OnMouseDown(EventData &data)
	{

	}

	void UIEngine::OnMouseUp(EventData &data)
	{

	}

	void UIEngine::OnMouseWheel(EventData &data)
	{

	}

	void UIEngine::OnWindowResize(EventData &data)
	{

	}
}
