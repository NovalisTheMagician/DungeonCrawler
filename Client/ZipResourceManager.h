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
		AT_TEXTURE,
		AT_VERTEXSHADER,
		AT_PIXELSHADER
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

		int LoadAsset(int type, const std::string &file) override;

	private:
		std::string GetDirectoryByType(int type) const;

	private:
		std::string filesystemPath;
		bool useFilesystem;

		int currentIndex;
		std::map<int, AssetType> loaded;
		std::map<const std::string, int> cache;

		std::vector<libzip::archive> archives;
		std::map<std::string, std::unique_ptr<uint8_t>> fileCache;

		Config &config;
		EventEngine &eventEngine;
		const SystemLocator &systems;
	};
}
