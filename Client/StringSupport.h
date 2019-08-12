#pragma once

#include <string>
#include <algorithm>
#include <locale>
#include <cwctype>

//from:
// https://stackoverflow.com/questions/25829143/trim-whitespace-from-a-string/25829178
// https://stackoverflow.com/questions/42022182/converting-wstring-to-lower-case

namespace DunCraw
{
	inline std::string& ltrim(std::string &str)
	{
		auto it2 = std::find_if(str.begin(), str.end(), [](char ch) { return !std::isspace<char>(ch, std::locale::classic()); });
		str.erase(str.begin(), it2);
		return str;
	}

	inline std::string& rtrim(std::string &str)
	{
		auto it1 = std::find_if(str.rbegin(), str.rend(), [](char ch) { return !std::isspace<char>(ch, std::locale::classic()); });
		str.erase(it1.base(), str.end());
		return str;
	}

	inline std::string& trim(std::string &str)
	{
		return ltrim(rtrim(str));
	}

	inline std::string trim_copy(std::string const &str)
	{
		auto s = str;
		return ltrim(rtrim(s));
	}

	inline std::wstring& lowerCase(std::wstring &str)
	{
		std::transform(str.begin(), str.end(), str.begin(), std::towlower);
		return str;
	}
}
