#include "Log.h"

#include <iomanip>
#include <ctime>

using std::string;
using std::wstring;
using std::ofstream;

namespace DunCraw
{
	ofstream Log::logFile(L"");

	Log::Log()
	{
	}

	Log::~Log()
	{
	}

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
		auto time = std::time(nullptr);
		auto tm = std::localtime(&time);
		stream << "[" << std::put_time(tm, "%d-%m-%Y %H-%M-%S") << "]";
	}
}
