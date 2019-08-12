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

		bool Open() override;
		void Close() override;

		void SetIcon(const std::wstring &iconFile) override;
		void SetTitle(const std::wstring &titleText) override;

	private:
		HWND hWnd;
		HINSTANCE hInstance;

		Config &config;
	};
}
