#pragma once

#include "DunCraw.h"

#include "IResourceManager.h"

#pragma warning(push)
#pragma warning(disable : 4244)
#pragma warning(disable : 4996)
#pragma warning(disable : 4267)
#pragma warning(disable : 4267)
#include <zip.hpp>
#pragma warning(pop)

namespace DunCraw
{
	enum AssetType
	{
		AT_NONE,
		AT_TEXTURE,
		AT_VERTEXSHADER,
		AT_PIXELSHADER,
		AT_SOUND
	};

	class ZipResourceManager : public IResourceManager
	{
	public:
		ZipResourceManager(Config &config, EventEngine &eventEngine, const SystemLocator &systemLocator, const std::string &filesystemPath = "");
		~ZipResourceManager();

		ZipResourceManager(const ZipResourceManager &rm) = delete;
		ZipResourceManager& operator=(const ZipResourceManager &rm) = delete;

		bool Init(const std::string &mainFile) override;
		bool AddPatchFile(const std::string &patchFile) override;
		void Destroy() override;

		Index LoadAsset(int type, const std::string &file) override;
		uint8_t *GetAssetData(const Index &index, size_t *size) override;
		void UnloadAsset(const Index &index);

	private:
		std::string GetDirectoryByType(int type) const;

	private:
		std::string filesystemPath;
		bool useFilesystem;

		Index currentIndex;
		std::map<Index, AssetType> loaded;
		std::map<const std::string, Index> indexCache;

		std::vector<libzip::archive> archives;
		std::map<Index, std::unique_ptr<uint8_t>> fileCache;
		std::map<Index, size_t> fileSizeCache;

		Config &config;
		EventEngine &eventEngine;
		const SystemLocator &systems;
	};
}
