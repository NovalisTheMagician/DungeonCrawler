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

		bool Open(const std::wstring &titleText) override;
		void Close() override;

		const void* Handle() override;

	private:
		HWND hWnd;
		HINSTANCE hInstance;

		Config &config;

		static const std::wstring CLASS_NAME;
	};
}
