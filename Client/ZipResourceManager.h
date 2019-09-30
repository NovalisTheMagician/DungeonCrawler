#pragma once

#include "DunCraw.h"

#include "IResourceManager.h"
#include <zip.hpp>

namespace DunCraw
{
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

	private:
		

	private:
		std::string filesystemPath;
		bool useFilesystem;

		std::vector<libzip::archive> archives;
		std::map<std::string, std::unique_ptr<uint8_t>> fileCache;

		Config &config;
		EventEngine &eventEngine;
		const SystemLocator &systems;
	};
}
