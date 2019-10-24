#pragma once

namespace DunCraw
{
	class IScriptEngine
	{
	public:
		virtual ~IScriptEngine() {};

		virtual bool RunScript() = 0;

	};
}
