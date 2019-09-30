#include "GameLoop.h"

#include "WinWindow.h"
#include "DXRenderer.h"
#include "DXAudioEngine.h"
#include "ZipResourceManager.h"
#include "LuaScriptEngine.h"

#include "StringSupport.h"

using std::string;
using std::wstring;

namespace DunCraw
{
	const float GameLoop::TARGET_DELTA = 1.0f / 60.0f;
	const string &GameLoop::MAIN_ARCHIVE_FILE = "campaign.zip";
	const string &GameLoop::ASSET_FILESYSTEM_PATH = "assets";

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
		window.reset(new WinWindow(config, eventEngine, locator, hInstance));
		if (!window->Open(L"Dungeon Crawler"))
		{
			Log::Error("Window creation failed! Cancelling Game...");
			return false;
		}
		locator.Provide(window.get());

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

		resourceManager.reset(new ZipResourceManager(config, eventEngine, locator, filesystemPath));
		if (!resourceManager->Init(mainArchive))
		{
			Log::Error("ResourceManager creation failed! Cancelling Game...");
			return false;
		}
		locator.Provide(resourceManager.get());

		bool strictPatch = args.IsSet(L"-strict");
		auto &patchFiles = args.GetParameters(L"-file");
		for (wstring patchFile : patchFiles)
		{
			if (!resourceManager->AddPatchFile(wstringToString(patchFile)) && strictPatch)
			{
				Log::Error("Exiting due to the -strict flag...");
				return false;
			}
		}

		renderer.reset(new DXRenderer(config, eventEngine, locator, reinterpret_cast<HWND>(window->Handle())));
		if (!renderer->Init())
		{
			Log::Error("Renderer creation failed! Cancelling Game...");
			return false;
		}
		locator.Provide(renderer.get());

		audioEngine.reset(new DXAudioEngine(config, eventEngine, locator));
		if (!audioEngine->Init())
		{
			Log::Error("AudioEngine creation failed! Cancelling Game...");
			return false;
		}
		locator.Provide(audioEngine.get());

		uiEngine.reset(new UIEngine(config, eventEngine, locator));
		if (!uiEngine->Init())
		{
			Log::Error("UIEngine creation failed! Cancelling Game...");
			return false;
		}

		scriptEngine.reset(new LuaScriptEngine(config, eventEngine, locator));
		if (!scriptEngine->Init())
		{
			Log::Error("ScriptEngine creation failed! Cancelling Game...");
			return false;
		}
		locator.Provide(scriptEngine.get());

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
