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
		: config(config), eventEngine(eventEngine), filesystemPath(filesystemPath), useFilesystem(!filesystemPath.empty()), systems(systemLocator),
			currentIndex(0), loaded(), indexCache(), fileSizeCache()
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
		loaded.clear();
		indexCache.clear();
		fileSizeCache.clear();
	}

	Index ZipResourceManager::LoadAsset(AssetType type, const std::string &file)
	{
		bool found = false;
		uint8_t *data = nullptr;
		size_t size = 0;

		path assetPath = GetDirectoryByType(type);
		assetPath /= file;

		if (indexCache.count(assetPath.string()) > 0)
		{
			int index = indexCache.at(assetPath.string());
			if (loaded.at(index) == type)
			{
				return index;
			}
		}

		if (useFilesystem)
		{
			path fsPath = filesystemPath / assetPath;

			fstream dataFile(fsPath, fstream::in | fstream::binary | fstream::ate);
			if (dataFile)
			{
				size = dataFile.tellg();
				dataFile.seekg(0, fstream::beg);
				data = new uint8_t[size];

				dataFile.read(reinterpret_cast<char*>(data), size);
				
				found = true;
			}
		}

		if (!found)
		{
			for (auto it = archives.rbegin(); it != archives.rend(); it++)
			{
				libzip::archive &archive = *it;
				if (archive.exists(assetPath.string()))
				{
					libzip::stat stat = archive.stat(assetPath.string());
					libzip::file dataFile = archive.open(assetPath.string());
					size = stat.size;
					data = new uint8_t[size];

					dataFile.read(data, size);

					found = true;
					break;
				}
			}
		}

		if (!found)
			return -1;

		bool success = false;
		int index = currentIndex++;

		switch (type)
		{
		case AT_TEXTURE:
			success = systems.GetRenderer().LoadTexture(data, size, index);
			break;
		case AT_VERTEXSHADER:
			success = systems.GetRenderer().LoadShader(data, size, ST_VERTEX, index);
			break;
		case AT_PIXELSHADER:
			success = systems.GetRenderer().LoadShader(data, size, ST_PIXEL, index);
			break;
		case AT_SOUND:
			success = systems.GetAudioEngine().LoadSound(data, size, index);
			break;
		}

		//delete[] data;

		if (!success)
		{
			Log::Error("Failed to load asset \"" + assetPath.string() + "\"");
			return -1;
		}

		loaded[index] = type;
		indexCache[assetPath.string()] = index;
		fileCache.emplace(index, std::move(data));
		fileSizeCache[index] = size;
		return index;
	}

	uint8_t *ZipResourceManager::GetAssetData(const Index &index, size_t *size)
	{
		if (fileCache.count(index) > 0)
		{
			*size = fileSizeCache[index];
			return fileCache[index].get();
		}
		return nullptr;
	}

	void ZipResourceManager::UnloadAsset(const Index &index)
	{
		if (fileCache.count(index) > 0)
		{
			fileCache.erase(index);
			fileSizeCache.erase(index);
			loaded[index] = AT_NONE;
		}
	}

	string ZipResourceManager::GetDirectoryByType(AssetType type) const
	{
		switch (type)
		{
		case AT_TEXTURE: return "Textures";
		case AT_VERTEXSHADER:
		case AT_PIXELSHADER: return "Shader";
		case AT_SOUND: return "Sounds";
		default: return "";
		}
	}
}
