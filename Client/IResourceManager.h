#pragma once

#include "DunDef.h"

#include <cstddef>

namespace DunCraw
{
	enum AssetType
	{
		AT_NONE,
		AT_TEXTURE,
		AT_SHADER,
		AT_SOUND,
		AT_MISC
	};

	class IResourceManager
	{
	public:
		virtual ~IResourceManager() {}

		virtual bool Init(const std::string &mainFile) = 0;
		virtual bool AddPatchFile(const std::string &patchFile) = 0;
		virtual void Destroy() = 0;
		virtual Index LoadAsset(AssetType type, const std::string &file) = 0;
		virtual std::byte *GetAssetData(const Index &index, size_t *size) = 0;
		virtual void UnloadAsset(const Index &index, bool cascade = false) = 0;
	};
}
