#pragma once

namespace DunCraw
{
	class IRenderer
	{
	public:
		virtual bool Init() = 0;
		virtual void Destroy() = 0;
	};
}
