#include "UICommon.hlsli"

VertexOut main(VertexIn vertIn)
{
	VertexOut vertOut;
    float2 screen = float2(vertIn.position.x / 800, vertIn.position.y / 600);
    screen = screen - float2(1, 1);
    vertOut.position = float4(screen, 0, 1);
    vertOut.texCoord = vertIn.texCoord * float2(1, -1);
	vertOut.color = vertIn.color;
	return vertOut;
}