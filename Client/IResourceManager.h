#pragma once

#include "DunCraw.h"

namespace DunCraw
{
	class IResourceManager
	{
	public:
		virtual ~IResourceManager() {}

		virtual bool Init(const std::string &mainFile) = 0;
		virtual bool AddPatchFile(const std::string &patchFile) = 0;
		virtual void Destroy() = 0;
		virtual Index LoadAsset(int type, const std::string &file) = 0;
		virtual uint8_t *GetAssetData(const Index &index, size_t *size) = 0;
		virtual void UnloadAsset(const Index &index) = 0;
	};
}
