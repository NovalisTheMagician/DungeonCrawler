#pragma once

#include <string>
namespace DunCraw
{
	class IWindow
	{
	public:
		virtual bool Open(const std::wstring &titleText) = 0;
		virtual void Close() = 0;

		virtual const void* Handle() = 0;

	};
}
