#pragma once

#include "DunDef.h"

#include <cstddef>

namespace DunCraw
{
	enum class AssetType
	{
		NONE,
		TEXTURE,
		SHADER,
		SOUND,
		MISC
	};

	class IResourceManager
	{
	public:
		virtual ~IResourceManager() {}

		virtual bool AddPatchFile(const std::string &patchFile) = 0;
		virtual Index LoadAsset(AssetType type, const std::string &file) = 0;
		virtual std::byte *GetAssetData(const Index &index, size_t *size) = 0;
		virtual void UnloadAsset(const Index &index, bool cascade = false) = 0;
	};
}
