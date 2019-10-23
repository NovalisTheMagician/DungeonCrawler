struct VertexIn
{
	float2 position : POSITION;
	float2 texCoord : TEXCOORD;
	float4 color : COLOR;
};

struct VertexOut
{
	float4 position : SV_POSITION;
	float2 texCoord : TEXCOORD;
	float4 color : COLOR;
};

cbuffer UITransform : register(b0)
{
	float viewWidth;
	float viewHeight;
	float2 elemPosition;
	float4 tint;
};