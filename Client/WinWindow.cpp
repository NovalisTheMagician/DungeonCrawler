#include "WinWindow.h"

#include "resource.h"

#include <windowsx.h>

using std::wstring;
using std::placeholders::_1;

namespace DunCraw
{
	static LRESULT WndProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

	const wstring WinWindow::CLASS_NAME = L"DungeonCrawlerWindow";

	WinWindow::WinWindow(Config &config, EventEngine &eventEngine, const SystemLocator &systemLocator, HINSTANCE hInstance)
		: config(config), eventEngine(eventEngine), hInstance(hInstance), systems(systemLocator), showCursor(true)
	{
	}

	WinWindow::~WinWindow()
	{
		Close();
		UnregisterClass(CLASS_NAME.c_str(), hInstance);
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

		Log::Info("Window created with dimensions " + std::to_string(width) + "x" + std::to_string(height));

		SetWindowLongPtr(hWnd, GWLP_USERDATA, reinterpret_cast<LONG_PTR>(this));

		eventEngine.RegisterCallback(EV_EXIT, std::bind(&WinWindow::OnExit, this, _1));
		eventEngine.RegisterCallback(EV_SHOWCURSOR, std::bind(&WinWindow::OnShowCursor, this, _1));

		RAWINPUTDEVICE dev;
		dev.usUsagePage = 1;
		dev.usUsage = 2;
		dev.dwFlags = 0;
		dev.hwndTarget = hWnd;
		if (!RegisterRawInputDevices(&dev, 1, sizeof dev))
		{
			Log::Error("Couldn't register raw mouse input. Not receiving any relative mouse movment...");
		}
		else
		{
			Log::Info("Registered RAWMOUSE input");
		}

		ShowWindow(hWnd, SW_SHOW);

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
		bool quit = false;
		while (PeekMessage(&msg, nullptr, 0, 0, PM_REMOVE))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);

			if (msg.message == WM_QUIT) 
			{
				exitCode = static_cast<int>(msg.wParam);
				quit = true;
				break;
			}
		}

		return quit;
	}

	void WinWindow::OnExit(EventData data)
	{
		Close();
	}

	void WinWindow::OnShowCursor(EventData data)
	{
		showCursor = data.A;
		ShowCursor(showCursor);
		if (!showCursor)
		{
			ConfineCursor();
		}
		else
		{
			ReleaseCursor();
		}
	}

	void WinWindow::ConfineCursor()
	{
		RECT rect;
		GetWindowRect(hWnd, &rect);
		ClipCursor(&rect);
		SetCapture(hWnd);
	}

	void WinWindow::ReleaseCursor()
	{
		ClipCursor(nullptr);
		ReleaseCapture();
	}

	LRESULT WinWindow::EventHandler(UINT uMsg, WPARAM wParam, LPARAM lParam)
	{
		switch (uMsg)
		{
		case WM_SIZE:
			{
				if (!showCursor)
					ConfineCursor();

				EventData data =
				{
					LOWORD(lParam),
					HIWORD(lParam),
					0,
					nullptr
				};
				eventEngine.SendEvent(EV_RESIZE, data, true);
			}
			break;
		case WM_CLOSE:
			DestroyWindow(hWnd);
			break;
		case WM_DESTROY:
			{
				RAWINPUTDEVICE dev;
				dev.usUsagePage = 1;
				dev.usUsage = 2;
				dev.dwFlags = RIDEV_REMOVE;
				dev.hwndTarget = hWnd;
				RegisterRawInputDevices(&dev, 1, sizeof dev);
				PostQuitMessage(0);
			}
			break;
		case WM_KEYUP:
			{
				EventData data =
				{
					static_cast<int>(wParam),
					0,
					0,
					nullptr
				};
				eventEngine.SendEvent(EV_KEYUP, data);
			}
			break;
		case WM_KEYDOWN:
			{
				EventData data =
				{
					static_cast<int>(wParam),
					0,
					0,
					nullptr
				};
				eventEngine.SendEvent(EV_KEYDOWN, data);
			}
			break;
		case WM_CHAR:
			{
				EventData data =
				{
					static_cast<int>(wParam),
					0,
					0,
					nullptr
				};
				eventEngine.SendEvent(EV_CHAR, data);
			}
			break;
		case WM_LBUTTONDOWN:
		case WM_RBUTTONDOWN:
		case WM_MBUTTONDOWN:
		case WM_XBUTTONDOWN:
			{
				EventData data =
				{
					static_cast<int>(wParam),
					0,
					0,
					nullptr
				};
				eventEngine.SendEvent(EV_MOUSEDOWN, data);
			}
			break;
		case WM_LBUTTONUP:
		case WM_RBUTTONUP:
		case WM_MBUTTONUP:
		case WM_XBUTTONUP:
			{
				EventData data =
				{
					static_cast<int>(wParam),
					0,
					0,
					nullptr
				};
				eventEngine.SendEvent(EV_MOUSEUP, data);
			}
			break;
		case WM_MOUSEMOVE:
			{
				short x = GET_X_LPARAM(lParam);
				short y = GET_Y_LPARAM(lParam);
				EventData data =
				{
					static_cast<int>(x),
					static_cast<int>(y),
					0,
					nullptr
				};
				eventEngine.SendEvent(EV_MOUSEMOVEABS, data);
			}
			break;
		case WM_MOUSEWHEEL:
			{
				short wheelVal = GET_WHEEL_DELTA_WPARAM(wParam);
				EventData data =
				{
					static_cast<int>(wheelVal / WHEEL_DELTA),
					static_cast<int>(wheelVal),
					static_cast<int>(WHEEL_DELTA),
					nullptr
				};
				eventEngine.SendEvent(EV_MOUSEWHEEL, data);
			}
			break;
		case WM_INPUT:
			{
				UINT dwSize;
				GetRawInputData((HRAWINPUT)lParam, RID_INPUT, nullptr, &dwSize, sizeof(RAWINPUTHEADER));
				BYTE *dataPtr = new BYTE[dwSize];
				if (GetRawInputData((HRAWINPUT)lParam, RID_INPUT, dataPtr, &dwSize, sizeof(RAWINPUTHEADER)) != dwSize)
				{
					Log::Warning("GetRawInputData does not return correct size !");
				}

				RAWINPUT *rawData = reinterpret_cast<RAWINPUT*>(dataPtr);
				if (rawData->header.dwType == RIM_TYPEMOUSE)
				{
					if (rawData->data.mouse.usFlags == MOUSE_MOVE_RELATIVE)
					{
						LONG x = rawData->data.mouse.lLastX;
						LONG y = rawData->data.mouse.lLastY;

						EventData data =
						{
							static_cast<int>(x),
							static_cast<int>(y),
							0,
							nullptr
						};
						eventEngine.SendEvent(EV_MOUSEMOVEREL, data);
					}
				}

				delete[] dataPtr;
			}
			break;
		case WM_MOVE:
			{
				if (!showCursor)
					ConfineCursor();
			}
			break;
		case WM_SETFOCUS:
			{
				
			}
			break;
		case WM_KILLFOCUS:
			{
				
			}
			break;
		case WM_ACTIVATE:
			{
				if (LOWORD(wParam) == WA_ACTIVE)
				{
					if (!showCursor)
						ConfineCursor();
				}
				else
				{
					if (!showCursor)
						ReleaseCursor();
				}
			}
			break;
		case WM_SYSCOMMAND:
			{
				if (wParam == SC_MINIMIZE)
				{
					EventData data =
					{
						0,
						0,
						0,
						nullptr
					};
					eventEngine.SendEvent(EV_WINDOWCHANGE, data, true);
				}
				else if (wParam == SC_RESTORE)
				{
					EventData data =
					{
						1,
						0,
						0,
						nullptr
					};
					eventEngine.SendEvent(EV_WINDOWCHANGE, data, true);
				}
			}
			return DefWindowProc(hWnd, uMsg, wParam, lParam);
		default: 
			return DefWindowProc(hWnd, uMsg, wParam, lParam);
		}
		return 0;
	}

	static LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
	{
		WinWindow *window = reinterpret_cast<WinWindow*>(GetWindowLongPtr(hWnd, GWLP_USERDATA));
		if (!window)
			return DefWindowProc(hWnd, uMsg, wParam, lParam);
		return window->EventHandler(uMsg, wParam, lParam);
	}
}

