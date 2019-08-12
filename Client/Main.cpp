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

	IWindow *window = new WinWindow(config, hInstance);
	window->Open(L"DungeonCrawler");

	MessageBox((HWND)window->Handle(), nullptr, nullptr, 0);

	window->Close();
	delete window;
	config.Close();
	Log::Close();
	return 0;
}
