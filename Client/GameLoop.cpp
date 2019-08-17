#include "GameLoop.h"

#include "WinWindow.h"
#include "DXRenderer.h"
#include "DXAudioEngine.h"
#include "ZipResourceManager.h"

#include "StringSupport.h"

using std::string;
using std::wstring;

namespace DunCraw
{
	const float GameLoop::TARGET_DELTA = 1.0f / 60.0f;
	const string &GameLoop::MAIN_ARCHIVE_FILE = "campagne.zip";

	GameLoop::GameLoop(Config &config, const Args &args)
		: config(config), eventEngine(config), args(args)
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

		string filesystemPath = "";
		if (args.IsSet(L"-debug"))
		{
			filesystemPath = ASSET_FILESYSTEM_PATH;
		}

		string mainArchive = MAIN_ARCHIVE_FILE;
		if (args.IsSet(L"-main"))
		{
			mainArchive = wstringToString(args.GetParameter(L"-main"));
		}

		resourceManager.reset(new ZipResourceManager(config, eventEngine, filesystemPath));
		if (!resourceManager->Init(mainArchive))
		{
			Log::Error("ResourceManager creation failed! Cancelling Game...");
			return false;
		}

		bool strictPatch = args.IsSet(L"-strict");
		for (wstring patchFile : args.GetParameters(L"-file"))
		{
			if (!resourceManager->AddPatchFile(wstringToString(patchFile)) && strictPatch)
			{
				Log::Error("Exiting due to the -strict flag...");
				return false;
			}
		}

		renderer.reset(new DXRenderer(config, eventEngine, reinterpret_cast<HWND>(window->Handle())));
		if (!renderer->Init())
		{
			Log::Error("Renderer creation failed! Cancelling Game...");
			return false;
		}

		audioEngine.reset(new DXAudioEngine(config, eventEngine));
		if (!audioEngine->Init())
		{
			Log::Error("AudioEngine creation failed! Cancelling Game...");
			return false;
		}

		uiEngine.reset(new UIEngine(config, eventEngine, *(renderer.get())));
		if (!uiEngine->Init())
		{
			Log::Error("UIEngine creation failed! Cancelling Game...");
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

		uiEngine->Draw();

		renderer->Present();
	}

	void GameLoop::Destroy()
	{
		uiEngine->Destroy();
		renderer->Destroy();
		audioEngine->Destroy();
		resourceManager->Destroy();
		window->Close();
	}
}
