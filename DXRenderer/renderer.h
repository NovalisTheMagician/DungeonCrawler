#pragma once

#include <d3d11.h>
#include <stdint.h>

extern "C" struct DXTexture
{
	uint32_t *bytes;
	int width;
	int height;
};

extern "C" struct DXMaterial
{
	DXTexture diffuse;
	DXTexture specular;
	DXTexture normal;
};

extern "C" struct DXModel
{
	//todo
};

class Renderer
{
public:
	Renderer();
	~Renderer();

	bool InitD3D();
	void ShutdownD3D();

private:


};
