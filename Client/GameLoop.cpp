#include "GameLoop.h"

#include "Timer.h"
#include "Log.h"

#include "WinWindow.h"
#include "DXRenderer.h"
#include "DXAudioEngine.h"

namespace DunCraw
{
	GameLoop::GameLoop(Config &config)
		: window(), renderer(), audioEngine(), config(config)
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
			Update(timer);
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
			Log::Error("Window creation failed! Cancelling Game...");
			return false;
		}

		renderer.reset(new DXRenderer(config, reinterpret_cast<HWND>(window->Handle())));
		if (!renderer->Init())
		{
			Log::Error("Renderer creation failed! Cancelling Game...");
			return false;
		}

		audioEngine.reset(new DXAudioEngine(config));
		if (!audioEngine->Init())
		{
			Log::Error("AudioEngine creation failed! Cancelling Game...");
			return false;
		}

		return true;
	}

	void GameLoop::Update(const Timer &timer)
	{

	}

	void GameLoop::Draw()
	{
		renderer->Clear();



		renderer->Present();
	}

	void GameLoop::Destroy()
	{
		window->Close();
		renderer->Destroy();
		audioEngine->Destroy();
	}
}
