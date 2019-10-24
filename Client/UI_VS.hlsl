#include "UICommon.hlsli"

VertexOut main(VertexIn vertIn)
{
	VertexOut vertOut;
	float2 position = vertIn.position + elemPosition;
    position.y = viewHeight - position.y;
    float2 screen = float2(position.x / viewWidth, position.y / viewHeight);
    screen = (screen * float2(2, 2)) - float2(1, 1);
    vertOut.position = float4(screen, 0, 1);
    vertOut.texCoord = vertIn.texCoord;
	vertOut.color = vertIn.color;
	return vertOut;
}