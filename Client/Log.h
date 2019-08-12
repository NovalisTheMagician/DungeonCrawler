#pragma once

#include <fstream>
#include <string>

namespace DunCraw
{
	class Log
	{
	public:
		static void Open(const std::wstring &logFilePath);
		static void Close();

		static void Info(const std::string &msg);
		static void Warning(const std::string &msg);
		static void Error(const std::string &msg);

	private:
		Log();
		~Log();

		static void PutTime(std::ofstream &stream);

	private:
		static std::ofstream logFile;

	};
}
