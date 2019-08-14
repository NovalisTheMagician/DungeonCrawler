#include "Log.h"

#include <iomanip>
#include <ctime>

using std::string;
using std::wstring;
using std::ofstream;

namespace DunCraw
{
	ofstream Log::logFile(L"");

	void Log::Open(const wstring &logFilePath)
	{
		logFile.open(logFilePath);
	}

	void Log::Close()
	{
		logFile.close();
	}

	void Log::Info(const string &msg)
	{
		PutTime(logFile);
		logFile << "[INFO]:" << msg << std::endl;
	}

	void Log::Warning(const string &msg)
	{
		PutTime(logFile);
		logFile << "[WARN]:" << msg << std::endl;
	}

	void Log::Error(const string &msg)
	{
		PutTime(logFile);
		logFile << "[ERRO]:" << msg << std::endl;
	}

	void Log::PutTime(ofstream &stream)
	{
		time_t time = std::time(nullptr);
		struct tm timeinfo;
		localtime_s(&timeinfo, &time);
		stream << "[" << std::put_time(&timeinfo, "%d-%m-%Y %H-%M-%S") << "]";
	}
}
