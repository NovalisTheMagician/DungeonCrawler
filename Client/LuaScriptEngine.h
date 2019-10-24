#pragma once

#include "DunCraw.h"

#include "IScriptEngine.h"

#include <lua.hpp>

namespace DunCraw
{
	class LuaScriptEngine : public IScriptEngine
	{
	public:
		LuaScriptEngine(Config &config, EventEngine &eventEngine, const SystemLocator &systemLocator);
		~LuaScriptEngine();

		bool RunScript() override;

	private:
		std::unique_ptr<lua_State, void (*)(lua_State*)> luaState;

		Config &config;
		EventEngine &eventEngine;

		const SystemLocator &systems;

	};
}
