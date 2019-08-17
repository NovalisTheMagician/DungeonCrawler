#include "ZipResourceManager.h"

using std::string;
using std::placeholders::_1;

namespace DunCraw
{
	ZipResourceManager::ZipResourceManager(Config &config, EventEngine &eventEngine, const string &filesystemPath)
		: config(config), eventEngine(eventEngine), filesystemPath(filesystemPath), useFilesystem(!filesystemPath.empty())
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
			archives.push_back(mainZip);
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

		eventEngine.RegisterCallback(EV_LOADRESOURCE, std::bind(&ZipResourceManager::OnLoadFile, this, _1));

		return true;
	}

	bool ZipResourceManager::AddPatchFile(const string &patchFile)
	{
		try
		{
			libzip::archive patchZip(patchFile);
			archives.push_back(patchZip);
		}
		catch (std::runtime_error er)
		{
			Log::Warning("Couldn't open patch archive: " + string(er.what()));
			return false;
		}

		return true;
	}

	void ZipResourceManager::OnLoadFile(EventData eventData)
	{
		string file = reinterpret_cast<char*>(eventData.Extra);

		LoadResourceType type = static_cast<LoadResourceType>(eventData.A);
		switch (type)
		{
		RT_TEXTURE:
			{

			}
			break;
		RT_SOUND:
			{

			}
			break;
		RT_MODEL:
			{

			}
			break;
		RT_TEXT:
			{

			}
			break;
		RT_LAYOUT:
			{

			}
			break;
		RT_SCRIPT:
			{

			}
			break;
		RT_CUSTOM:
			{

			}
			break;
		}
	}

	void ZipResourceManager::Destroy()
	{
		archives.clear();
		fileCache.clear();
	}
}
