#include "ZipResourceManager.h"

#include <filesystem>
#include <iterator>
#include <fstream>

using std::string;
using std::placeholders::_1;
using std::filesystem::path;
using std::fstream;

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

	int ZipResourceManager::LoadAsset(int type, const std::string &file)
	{
		bool found = false;
		uint8_t *data = nullptr;

		path p = GetDirectoryByType(type);
		p /= file;

		if (useFilesystem)
		{
			p = filesystemPath / p;

			fstream dataFile(p, fstream::in | fstream::binary | fstream::ate);
			if (dataFile)
			{
				size_t size = dataFile.tellg();
				dataFile.seekg(0, fstream::beg);
				data = new uint8_t[size];

				dataFile.read(reinterpret_cast<char*>(data), size);
				
				found = true;
			}
		}

		if (!found)
		{
			for (auto it = archives.rbegin(); it != archives.rend; it++)
			{
				libzip::archive &archive = *it;
				if (archive.exists(p.string()))
				{
					libzip::stat stat = archive.stat(p.string());
					libzip::file dataFile = archive.open(p.string());
					data = new uint8_t[stat.size];

					dataFile.read(data, stat.size);

					found = true;
					break;
				}
			}
		}

		if (!found)
			return -1;

		delete[] data;
		return -1;
	}

	string ZipResourceManager::GetDirectoryByType(int type) const
	{
		switch (type)
		{
		case AT_TEXTURE: return "Texture";
		default: return "";
		}
	}
}
