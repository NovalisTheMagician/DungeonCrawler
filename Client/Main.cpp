#define WIN32_LEAN_AND_MEAN
#define VC_EXTRALEAN
#include <Windows.h>
#include <iostream>
#include <string>

#include <ShlObj.h>
#include <filesystem>
#include <ShellScalingApi.h>
#pragma comment(lib, "Shcore.lib")

#include "Args.h"
#include "Log.h"
#include "Config.h"
#include "StringSupport.h"

#include "GameLoop.h"

using namespace DunCraw;

using std::wstring;
using std::filesystem::path;

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPWSTR lpCmdLine, int nCmdShow)
{
	SetProcessDpiAwareness(PROCESS_SYSTEM_DPI_AWARE);

	Log::Open(L"session.log");

	Log::Info("Comandline Parameters: " + wstringToString(lpCmdLine));

	path configFile;

	Args args(lpCmdLine);
	if (args.NumParameters(L"-config") == 1)
	{
		configFile = args.GetParameter(L"-config");
	}
	else
	{
		wchar_t *path;
		HRESULT hr = SHGetKnownFolderPath(FOLDERID_Documents, 0, nullptr, &path);
		if (SUCCEEDED(hr))
		{
			configFile = path;
			configFile /= L"FraylinBoons";
			configFile /= L"DungeonCrawler";
			configFile /= L"config.txt";

			CoTaskMemFree(path);
		}
	}

	if (args.IsSet(L"-recreateconfig"))
	{
		Log::Info("Regenerating config file with default values...");

		//TODO implement config recreation
		Config config;

		config.Close(configFile);
		return 0;
	}

	Log::Info("Using config file: " + wstringToString(configFile.wstring()));

	Config config;
	if (!config.Open(configFile.wstring()))
	{
		Log::Error("Couldn't find config File: " + wstringToString(configFile.wstring()) + " \tExiting...");
		Log::Close();
		return -1;
	}

	Log::Info("Successfully loaded config");

	GameLoop loop(config);
	int exitCode = loop.Start();

	Log::Info("Closing game with code " + std::to_string(exitCode));

	config.Close();
	Log::Close();
	return exitCode;
}
