#pragma once

#include "IWindow.h"
#include <Windows.h>

#include "DunCraw.h"

namespace DunCraw
{
	class WinWindow : public IWindow
	{
	public:
		WinWindow(Config &config, EventEngine &eventEngine, const SystemLocator &systemLocator, HINSTANCE hInstance);
		~WinWindow();
		WinWindow(const WinWindow&) = delete;
		WinWindow& operator=(const WinWindow&) = delete;

		bool Open(const std::wstring &titleText) override;
		void Close() override;

		void* Handle() override;

		bool DoEvents(int &exitCode) override;

		LRESULT EventHandler(UINT uMsg, WPARAM wParam, LPARAM lParam);

	private:
		void OnExit(EventData &data);
		void OnShowCursor(EventData &data);

		void ConfineCursor();
		void ReleaseCursor();

	private:
		HWND hWnd;
		HINSTANCE hInstance;

		bool showCursor;

		Config &config;
		EventEngine &eventEngine;
		const SystemLocator &systems;

		static const std::wstring CLASS_NAME;
	};
}
