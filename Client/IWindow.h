#pragma once

#include <string>
namespace DunCraw
{
	class IWindow
	{
	public:
		virtual ~IWindow() {}

		virtual bool Open(const std::wstring &titleText) = 0;
		virtual void Close() = 0;

		virtual bool DoEvents(int &exitCode) = 0;
		virtual void* Handle() = 0;

		//virtual void SetDefault() = 0;

	};
}
