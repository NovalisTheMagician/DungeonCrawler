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
		int LoadAsset(int type, const std::string &file) override { return -1; };
	};
}
