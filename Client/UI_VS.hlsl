struct VertexIn
{
	float2 position : POSITION;
	float2 texCoord : TEXCOORD;
};

struct VertexOut
{
	float4 position : SV_POSITION;
	float2 texCoord : TEXCOORD;
};

VertexOut main(VertexIn vertIn)
{
	VertexOut vertOut;
	vertOut.position = float4(vertIn.position, 0, 1);
	vertOut.texCoord = vertIn.texCoord;
	return vertOut;
}