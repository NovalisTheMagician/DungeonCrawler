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
	ZipResourceManager::ZipResourceManager(Config &config, EventEngine &eventEngine, const SystemLocator &systemLocator, const std::string &mainFile, const std::string &filesystemPath)
		: config(config), eventEngine(eventEngine), filesystemPath(filesystemPath), useFilesystem(!filesystemPath.empty()), systems(systemLocator),
			currentIndex(0)
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
				throw GameSystemException("ZipResourceManager");
			}
		}
	}

	ZipResourceManager::~ZipResourceManager()
	{
		archives.clear();
		fileCache.clear();
		loaded.clear();
		indexCache.clear();
		fileSizeCache.clear();
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

	Index ZipResourceManager::LoadAsset(AssetType type, const std::string &file)
	{
		bool found = false;
		std::byte *data = nullptr;
		size_t size = 0;

		path assetPath = GetDirectoryByType(type);
		assetPath /= file;

		if (indexCache.count(assetPath.string()) > 0)
		{
			Index index = indexCache.at(assetPath.string());
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
				data = new std::byte[size];

				dataFile.read(reinterpret_cast<char*>(data), size);
				
				found = true;
			}
		}

		if (!found)
		{
			for (auto it = archives.rbegin(); it != archives.rend(); it++)
			{
				libzip::archive &archive = *it;
				string path = assetPath.generic_string();
				if (archive.exists(path))
				{
					libzip::stat stat = archive.stat(path);
					libzip::file dataFile = archive.open(path);
					size = stat.size;
					data = new std::byte[size];

					dataFile.read(data, size);

					found = true;
					break;
				}
			}
		}

		if (!found)
		{
			Log::Error("Failed to find asset \"" + assetPath.generic_string() + "\"");
			return InvalidIndex;
		}

		bool success = false;
		Index index = currentIndex++;

		switch (type)
		{
		case AssetType::TEXTURE:
			success = systems.GetRenderer().LoadTexture(data, size, index);
			break;
		case AssetType::SOUND:
			success = systems.GetAudioEngine().LoadSound(data, size, index);
			break;
		case AssetType::SHADER:
		case AssetType::MISC:
			success = true;
			break;
		}

		if (!success)
		{
			Log::Error("Failed to load asset \"" + assetPath.generic_string() + "\"");
			return -1;
		}

		loaded[index] = type;
		indexCache[assetPath.generic_string()] = index;
		fileCache.emplace(index, std::move(data));
		fileSizeCache[index] = size;
		return index;
	}

	std::byte *ZipResourceManager::GetAssetData(const Index &index, size_t *size)
	{
		if (fileCache.count(index) > 0)
		{
			*size = fileSizeCache[index];
			return fileCache[index].get();
		}
		return nullptr;
	}

	void ZipResourceManager::UnloadAsset(const Index &index, bool cascade)
	{
		if (cascade && (loaded[index] != AssetType::NONE || loaded[index] != AssetType::MISC))
		{
			switch (loaded[index])
			{
			case AssetType::TEXTURE:
				systems.GetRenderer().UnloadTexture(index);
				break;
			case AssetType::SOUND:
				systems.GetAudioEngine().UnloadSound(index);
				break;
			}

			loaded[index] = AssetType::NONE;
		}

		if (fileCache.count(index) > 0)
		{
			fileCache.erase(index);
			fileSizeCache.erase(index);
			if(loaded[index] == AssetType::MISC)
				loaded[index] = AssetType::NONE;
		}
	}

	string ZipResourceManager::GetDirectoryByType(AssetType type) const
	{
		switch (type)
		{
		case AssetType::TEXTURE: return "Textures";
		case AssetType::SHADER: return "Shader";
		case AssetType::SOUND: return "Sounds";
		case AssetType::MISC: return "";
		default: return "";
		}
	}
}
