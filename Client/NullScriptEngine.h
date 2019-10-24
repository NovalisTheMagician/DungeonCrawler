#pragma once

#include "IScriptEngine.h"

namespace DunCraw
{
	class NullScriptEngine : public IScriptEngine
	{
	public:
		bool RunScript() override { return true; };
	};
}
