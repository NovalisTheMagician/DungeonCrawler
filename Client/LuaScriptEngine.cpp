#include "LuaScriptEngine.h"

#include "DunCraw.h"

namespace DunCraw
{
	LuaScriptEngine::LuaScriptEngine(Config & config, EventEngine & eventEngine, const SystemLocator & systemLocator)
		: config(config), eventEngine(eventEngine), systems(systemLocator), luaState(nullptr, lua_close)
	{
	}

	LuaScriptEngine::~LuaScriptEngine()
	{
		
	}

	bool LuaScriptEngine::Init()
	{
		luaState.reset(luaL_newstate());
		return true;
	}

	void LuaScriptEngine::Destroy()
	{

	}

	bool LuaScriptEngine::RunScript()
	{
		return false;
	}

}
