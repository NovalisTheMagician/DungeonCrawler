#include "WinWindow.h"

namespace DunCraw
{
	WinWindow::WinWindow(Config &config, HINSTANCE hInstance)
		: config(config), hWnd(nullptr), hInstance(hInstance)
	{
	}

	WinWindow::~WinWindow()
	{
	}

	bool WinWindow::Open()
	{
		return false;
	}

	void WinWindow::Close()
	{
	}

	void WinWindow::SetIcon(const std::wstring & iconFile)
	{
	}

	void WinWindow::SetTitle(const std::wstring & titleText)
	{
	}
}

