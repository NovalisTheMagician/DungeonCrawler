#pragma once

#include "DunCraw.h"

#include "IResourceManager.h"

namespace DunCraw
{
	class NullResourceManager : public IResourceManager
	{
	public:
		bool Init(const std::string &mainFile) override { return true; };
		bool AddPatchFile(const std::string &patchFile) override { return true; };
		void Destroy() override { };
		Index LoadAsset(int type, const std::string &file) override { return -1; };
		uint8_t *GetAssetData(const Index &index, size_t *size) override { return nullptr; };
		void UnloadAsset(const Index &index) override { };
	};
}
