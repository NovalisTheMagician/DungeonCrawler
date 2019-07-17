cbuffer PerFrame
{
    float4x4 viewProjection;
}

struct VertexIn
{
    float3 position;
    float3 normal;
    float2 texCoord;
}

struct VertexOut
{
    float4 position;
    float3 normal;
    float2 texCoord;
}

VertexOut main(in VertexIn v)
{

}
