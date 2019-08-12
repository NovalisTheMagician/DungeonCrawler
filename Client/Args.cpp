#include "Args.h"

#include <sstream>
#include "StringSupport.h"

using std::wstring;
using std::map;
using std::vector;
using std::wstringstream;

namespace DunCraw
{
	const wstring Args::EMPTY_STRING = L"";
	const vector<wstring> Args::EMPTY_PARAMETERS = vector<wstring>();

	Args::Args(const wstring &cmdLine)
		: args()
	{
		wstringstream ss(cmdLine);
		wstring flag;
		wstring parm;
		vector<wstring> parameters;

		ss >> flag;
		flag = lowerCase(flag);
		if (flag[0] != '-')
			return;

		while (ss)
		{
			ss >> parm;
			if (parm[0] != '-')
			{
				parameters.push_back(parm);
			}
			else
			{
				args[flag] = parameters;
				flag = parm;
				flag = lowerCase(flag);
				parameters.clear();
			}
		}
		args[flag] = parameters;
	}

	Args::~Args()
	{
		args.clear();
	}

	bool Args::IsSet(const std::wstring &flag) const
	{
		return args.count(flag) > 0;
	}

	int Args::NumParameters(const std::wstring &flag) const
	{
		if (IsSet(flag))
		{
			return static_cast<int>(args.at(flag).size());
		}
		return -1;
	}

	const std::wstring& Args::GetParameter(const std::wstring &flag) const
	{
		if (IsSet(flag))
		{
			return args.at(flag)[0];
		}
		return EMPTY_STRING;
	}

	const std::vector<std::wstring>& Args::GetParameters(const std::wstring &flag) const
	{
		if (IsSet(flag))
		{
			return args.at(flag);
		}
		return EMPTY_PARAMETERS;
	}
}
