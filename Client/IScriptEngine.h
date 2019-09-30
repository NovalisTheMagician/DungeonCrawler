#pragma once

namespace DunCraw
{
	class IScriptEngine
	{
	public:
		virtual ~IScriptEngine() {};

		virtual bool Init() = 0;
		virtual void Destroy() = 0;

		virtual bool RunScript() = 0;

	};
}
