#pragma once

#include <string>
#include <map>
#include <vector>

namespace DunCraw
{
	class Args
	{
	public:
		Args(const std::wstring &cmdLine);
		~Args();

		bool IsSet(const std::wstring &flag) const;
		int NumParameters(const std::wstring &flag) const;
		const std::wstring& GetParameter(const std::wstring &flag) const;
		const std::vector<std::wstring>& GetParameters(const std::wstring &flag) const;

	private:
		std::map<std::wstring, std::vector<std::wstring>> args;

		static const std::wstring EMPTY_STRING;
		static const std::vector<std::wstring> EMPTY_PARAMETERS;

	};
}
