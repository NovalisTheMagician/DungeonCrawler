#pragma once

#include "IScriptEngine.h"

namespace DunCraw
{
	class NullScriptEngine : public IScriptEngine
	{
	public:
		bool Init() override { return true; };
		void Destroy() override { };

		bool RunScript() override { return true; };
	};
}
