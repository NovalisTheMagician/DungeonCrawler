#pragma once

#include "IWindow.h"
#include <Windows.h>

#include <string>

#include "Config.h"

namespace DunCraw
{
	class WinWindow : public IWindow
	{
	public:
		WinWindow(Config &config, HINSTANCE hInstance);
		~WinWindow();
		WinWindow(const WinWindow&) = delete;
		WinWindow& operator=(const WinWindow&) = delete;

		bool Open(const std::wstring &titleText) override;
		void Close() override;

		void* Handle() override;

		bool DoEvents(int &exitCode) override;

		LRESULT EventHandler(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);		

	private:
		HWND hWnd;
		HINSTANCE hInstance;

		Config &config;

		static const std::wstring CLASS_NAME;
	};
}
