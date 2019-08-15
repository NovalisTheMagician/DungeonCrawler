#include "GameLoop.h"

#include "Timer.h"
#include "Log.h"

#include "WinWindow.h"
#include "DXRenderer.h"
#include "DXAudioEngine.h"

namespace DunCraw
{
	const float GameLoop::TARGET_DELTA = 1.0f / 60.0f;

	GameLoop::GameLoop(Config &config)
		: config(config), eventEngine(config)
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

		float accum = 0;
		while (!window->DoEvents(exitCode))
		{
			timer.Update();
			eventEngine.ProcessQueue();
			Update(timer);
			accum += timer.Delta();
			while (accum >= TARGET_DELTA)
			{
				FixedUpdate(timer);
				accum -= TARGET_DELTA;
			}
			Draw();
		}

		Destroy();

		return exitCode;
	}

	bool GameLoop::Initialize()
	{
		if (!InitSubsystems())
			return false;

		return true;
	}

	bool GameLoop::InitSubsystems()
	{
		HINSTANCE hInstance = GetModuleHandle(nullptr);
		window.reset(new WinWindow(config, eventEngine, hInstance));
		if (!window->Open(L"Dungeon Crawler"))
		{
			Log::Error("Window creation failed! Cancelling Game...");
			return false;
		}

		renderer.reset(new DXRenderer(config, eventEngine, reinterpret_cast<HWND>(window->Handle())));
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

	void GameLoop::FixedUpdate(const Timer &timer)
	{

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
		renderer->Destroy();
		audioEngine->Destroy();
		window->Close();
	}
}
