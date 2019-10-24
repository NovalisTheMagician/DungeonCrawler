#include "LuaScriptEngine.h"

#include "DunCraw.h"

namespace DunCraw
{
	LuaScriptEngine::LuaScriptEngine(Config & config, EventEngine & eventEngine, const SystemLocator & systemLocator)
		: config(config), eventEngine(eventEngine), systems(systemLocator), luaState(nullptr, lua_close)
	{
		luaState.reset(luaL_newstate());
	}

	LuaScriptEngine::~LuaScriptEngine()
	{
		
	}

	bool LuaScriptEngine::RunScript()
	{
		return false;
	}
}
