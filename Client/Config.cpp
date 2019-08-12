#include "Config.h"
#include <fstream>

#include "StringSupport.h"

using std::string;
using std::wstring;
using std::stringstream;

using std::ifstream;
using std::ofstream;

namespace DunCraw
{
	Config::Config()
		: configMap(), configPath(L""), open(false)
	{

	}

	Config::~Config()
	{
		Close();
	}

	bool Config::Open(const wstring &configPath)
	{
		ifstream inputStream(configPath);
		if (!inputStream)
			return false;

		this->configPath = configPath;
		string line;
		while (std::getline(inputStream, line))
		{
			if (line[0] == '/' && line[1] == '/') continue;

			stringstream ss(line);
			string key, value;
			std::getline(ss, key, '=');
			std::getline(ss, value, '=');

			trim(key);
			trim(value);

			configMap[key] = value;
		}

		open = true;
		return true;
	}

	void Config::Close()
	{
		if (open)
		{
			ofstream outputStream(configPath);
			if (outputStream)
			{
				for (auto const&[key, val] : configMap)
				{
					outputStream << key << "=" << val << std::endl;
				}
			}

			configMap.clear();

			open = false;
		}
	}

	const string& Config::GetString(const string &key, const string &def) const
	{
		if (configMap.count(key) > 0)
		{
			return configMap.at(key);
		}
		return def;
	}

	int Config::GetInt(const string &key, const int &def) const
	{
		if (configMap.count(key) > 0)
		{
			stringstream ss(configMap.at(key));
			int val;
			ss >> val;
			return val;
		}
		return def;
	}
}
