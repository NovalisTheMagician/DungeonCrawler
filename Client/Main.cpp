#include <Windows.h>
#include <iostream>

#include "Args.h"
#include "Log.h"
#include "Config.h"
#include "IWindow.h"
#include "WinWindow.h"

using namespace DunCraw;

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPWSTR lpCmdLine, int nCmdShow)
{
	Log::Open(L"session.log");

	Args args(lpCmdLine);
	if (args.IsSet(L"-debug"))
		Log::Info("Debugmode activated");

	Config config;
	if (!config.Open(L"config.txt"))
		Log::Error("Couldn't find config File");

	Log::Info("Hello World!");
	Log::Info(config.GetString("window_width", "error"));
	Log::Info(config.GetString("fullscreen", "error"));
	Log::Warning("Again!");
	Log::Error("All your bases are belong to us!");

	config.SetValue("fullscreen", 0);
	config.SetValue("debug", 1);
	config.SetValue("truth", false);

	MessageBox(nullptr, L"Hello World!", L"", MB_OK);

	config.Close();
	Log::Close();
	return 0;
}
