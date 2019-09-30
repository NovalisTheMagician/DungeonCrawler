#pragma once

#include "DunCraw.h"

#include "IWindow.h"

namespace DunCraw
{
	class NullWindow : public IWindow
	{
	public:
		bool Open(const std::wstring &titleText) override { return true; };
		void Close() override { };

		bool DoEvents(int &exitCode) override { return false; };
		void* Handle() { return nullptr; };
	};
}
