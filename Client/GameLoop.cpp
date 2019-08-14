#include "GameLoop.h"

#include "Timer.h"
#include "Log.h"

#include "WinWindow.h"

namespace DunCraw
{
	GameLoop::GameLoop(Config &config)
		: window(), renderer(), config(config)
	{

	}

	GameLoop::~GameLoop()
	{

	}

	int GameLoop::Start()
	{
		if (!Initialize())
			return -1;

		Timer timer;
		int exitCode;
		while (!window->DoEvents(exitCode))
		{
			timer.Update();
			Update(timer.Delta());
			Draw();
		}

		Destroy();

		return exitCode;
	}

	bool GameLoop::Initialize()
	{
		HINSTANCE hInstance = GetModuleHandle(nullptr);
		window.reset(new WinWindow(config, hInstance));
		if (!window->Open(L"DungeonCrawler"))
		{
			Log::Error("Window creation failed! Canceling Game...");
			return false;
		}
		return true;
	}

	void GameLoop::Update(float delta)
	{

	}

	void GameLoop::Draw()
	{

	}

	void GameLoop::Destroy()
	{

	}
}
