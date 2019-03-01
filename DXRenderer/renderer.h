#pragma once

#include <d3d11.h>

class Renderer
{
public:
	Renderer();
	~Renderer();

	bool InitD3D();
	void ShutdownD3D();

private:


};
