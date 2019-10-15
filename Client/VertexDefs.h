#pragma once

#include <DirectXMath.h>

namespace DunCraw
{
	struct UIVertex
	{
		DirectX::XMFLOAT2 position;
		DirectX::XMFLOAT2 textureCoord;
		DirectX::XMFLOAT4 color;
	};

	struct StaticModelVertex
	{
		DirectX::XMFLOAT3 position;
		DirectX::XMFLOAT2 textureCoord;
		DirectX::XMFLOAT3 normal;
	};
}
