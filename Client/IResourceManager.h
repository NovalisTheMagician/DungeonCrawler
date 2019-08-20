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
	};
}
