#pragma once

#include <string>
namespace DunCraw
{
	class IWindow
	{
	public:
		virtual bool Open() = 0;
		virtual void Close() = 0;

		virtual void SetIcon(const std::wstring &iconFile) = 0;
		virtual void SetTitle(const std::wstring &titleText) = 0;

	};
}
