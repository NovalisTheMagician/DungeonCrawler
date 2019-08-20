#pragma once

namespace DunCraw
{
	class IRenderer
	{
	public:
		virtual ~IRenderer() {}

		virtual bool Init() = 0;
		virtual void Destroy() = 0;

		virtual void Clear() = 0;
		virtual void Present() = 0;
	};
}
