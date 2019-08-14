#pragma once

#include <map>
#include <string>
#include <sstream>

namespace DunCraw
{
	class Config
	{
	public:
		Config();
		~Config();
		Config(const Config&) = delete;
		Config& operator=(const Config&) = delete;

		bool Open(const std::wstring &configPath);
		void Close(const std::wstring &forceConfigPath = L"");

		const std::string& GetString(const std::string &key, const std::string &def) const;
		int GetInt(const std::string &key, const int &def) const;

		template<typename T>
		void SetValue(const std::string &key, const T &value);

	private:
		std::map<std::string, std::string> configMap;
		std::wstring configPath;

		bool open;

	};

	template<typename T>
	void Config::SetValue(const std::string &key, const T &value)
	{
		std::stringstream sstream;
		sstream << value;
		configMap[key] = sstream.str();
	}
}
