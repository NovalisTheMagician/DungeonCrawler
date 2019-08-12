#include "WinWindow.h"

#include "resource.h"

using std::wstring;

namespace DunCraw
{
	static LRESULT WndProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

	const wstring WinWindow::CLASS_NAME = L"DungeonCrawlerWindow";

	WinWindow::WinWindow(Config &config, HINSTANCE hInstance)
		: config(config), hWnd(nullptr), hInstance(hInstance)
	{
	}

	WinWindow::~WinWindow()
	{
	}

	bool WinWindow::Open(const std::wstring &titleText)
	{
		WNDCLASSEX wnd = { 0 };
		wnd.cbSize = sizeof wnd;
		wnd.lpszClassName = CLASS_NAME.c_str();
		wnd.hInstance = hInstance;
		wnd.lpfnWndProc = WndProc;
		wnd.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_ICON1));
		wnd.style = CS_VREDRAW | CS_OWNDC | CS_HREDRAW;

		RegisterClassEx(&wnd);

		int width = config.GetInt("window_width", 800);
		int height = config.GetInt("window_height", 600);

		hWnd = CreateWindowEx(	0, 
								CLASS_NAME.c_str(), 
								titleText.c_str(),
								WS_OVERLAPPEDWINDOW, 
								CW_USEDEFAULT, CW_USEDEFAULT, 
								width, height, 
								nullptr, nullptr, 
								hInstance, nullptr);

		if (!hWnd)
		{
			return false;
		}

		ShowWindow(hWnd, SW_SHOW);

		return true;
	}

	void WinWindow::Close()
	{
		PostQuitMessage(0);
	}

	const void* WinWindow::Handle()
	{
		return hWnd;
	}

	static LRESULT CALLBACK WndProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
	{
		return DefWindowProc(hwnd, uMsg, wParam, lParam);
	}
}

