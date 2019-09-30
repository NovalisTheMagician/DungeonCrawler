#include "ZipResourceManager.h"

using std::string;
using std::placeholders::_1;

namespace DunCraw
{
	ZipResourceManager::ZipResourceManager(Config &config, EventEngine &eventEngine, const SystemLocator &systemLocator, const string &filesystemPath)
		: config(config), eventEngine(eventEngine), filesystemPath(filesystemPath), useFilesystem(!filesystemPath.empty()), systems(systemLocator)
	{
	}

	ZipResourceManager::~ZipResourceManager()
	{
		Destroy();
	}

	bool ZipResourceManager::Init(const string &mainFile)
	{
		try
		{
			libzip::archive mainZip(mainFile);
			archives.emplace_back(std::move(mainZip));
		}
		catch (std::runtime_error er)
		{
			if (useFilesystem)
			{
				Log::Warning("Couldn't open main archive: " + string(er.what()));
			}
			else
			{
				Log::Error("Couldn't open main archive: " + string(er.what()));
				return false;
			}
		}

		return true;
	}

	bool ZipResourceManager::AddPatchFile(const string &patchFile)
	{
		try
		{
			libzip::archive patchZip(patchFile);
			archives.emplace_back(std::move(patchZip));
		}
		catch (std::runtime_error er)
		{
			Log::Warning("Couldn't open patch archive: " + string(er.what()));
			return false;
		}

		return true;
	}

	void ZipResourceManager::Destroy()
	{
		archives.clear();
		fileCache.clear();
	}
}
