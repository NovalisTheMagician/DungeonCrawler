#include "WinWindow.h"

#include "resource.h"

#include "Log.h"

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
		Close();
	}

	bool WinWindow::Open(const std::wstring &titleText)
	{
		WNDCLASSEX wnd = { 0 };
		wnd.cbSize = sizeof wnd;
		wnd.lpszClassName = CLASS_NAME.c_str();
		wnd.hInstance = hInstance;
		wnd.lpfnWndProc = WndProc;
		wnd.hbrBackground = (HBRUSH)GetStockObject(COLOR_WINDOW + 1);
		wnd.hCursor = LoadCursor(hInstance, IDC_ARROW);
		wnd.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_ICON1));
		wnd.hIconSm = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_ICON1));
		wnd.style = CS_VREDRAW | CS_OWNDC | CS_HREDRAW;

		RegisterClassEx(&wnd);

		int width = config.GetInt("r_width", 800);
		int height = config.GetInt("r_height", 600);
		int fullscreen = config.GetInt("r_fullscreen", 0);

		DWORD windowStyle = WS_OVERLAPPEDWINDOW;
		RECT rect = { 0, 0, width, height };
		int x = CW_USEDEFAULT, y = CW_USEDEFAULT;

		if (fullscreen == 0) // windowed
		{
			AdjustWindowRectEx(&rect, windowStyle, false, 0);
			Log::Info("Creating window in windowed mode");
		}
		if (fullscreen == 1) // fullscreen
		{
			//TODO implement normal fullscreen mode
			Log::Warning("Normal fullscreen mode not yet implemented. Defaulting to borderlessfullscreen");
			fullscreen = 2;
		}
		if (fullscreen == 2) // borderlessfullscreen
		{
			rect.right = GetSystemMetrics(SM_CXSCREEN);
			rect.bottom = GetSystemMetrics(SM_CYSCREEN);
			width = rect.right;
			height = rect.bottom;
			windowStyle = WS_POPUP;
			x = 0;
			y = 0;
			Log::Info("Creating window in borderlessfullscreen mode");
		}

		hWnd = CreateWindowEx(	0, 
								CLASS_NAME.c_str(), 
								titleText.c_str(), 
								windowStyle, 
								x, y, 
								rect.right - rect.left,
								rect.bottom - rect.top,
								nullptr, nullptr, 
								hInstance, nullptr);

		if (!hWnd)
		{
			Log::Error("Couldn't create window!");
			return false;
		}

		ShowWindow(hWnd, SW_SHOW);

		Log::Info("Window created with dimensions " + std::to_string(width) + "x" + std::to_string(height));

		SetWindowLongPtr(hWnd, GWLP_USERDATA, reinterpret_cast<LONG_PTR>(this));

		return true;
	}

	void WinWindow::Close()
	{
		PostQuitMessage(0);
	}

	void* WinWindow::Handle()
	{
		return hWnd;
	}

	bool WinWindow::DoEvents(int &exitCode)
	{
		MSG msg;
		while (PeekMessage(&msg, nullptr, 0, 0, PM_REMOVE))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}

		if (msg.message == WM_QUIT)
		{
			exitCode = static_cast<int>(msg.wParam);
			return true;
		}
		return false;
	}

	LRESULT WinWindow::EventHandler(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
	{
		switch (uMsg)
		{
		case WM_SIZE:
			break;
		case WM_CLOSE:
			DestroyWindow(hWnd);
			break;
		case WM_DESTROY:
			PostQuitMessage(0);
			break;
		default: 
			return DefWindowProc(hWnd, uMsg, wParam, lParam);
		}
		return 0;
	}

	static LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
	{
		WinWindow *window = reinterpret_cast<WinWindow*>(GetWindowLongPtr(hWnd, GWLP_USERDATA));
		return window->EventHandler(hWnd, uMsg, wParam, lParam);
	}
}

