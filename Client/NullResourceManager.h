#pragma once

#include "DunCraw.h"

#include "IResourceManager.h"

namespace DunCraw
{
	class NullResourceManager : public IResourceManager
	{
	public:
		bool AddPatchFile(const std::string &patchFile) override { return true; };
		Index LoadAsset(AssetType type, const std::string &file) override { return -1; };
		std::byte *GetAssetData(const Index &index, size_t *size) override { return nullptr; };
		void UnloadAsset(const Index &index, bool cascade) override { };
	};
}
