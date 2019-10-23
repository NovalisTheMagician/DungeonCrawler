#include "UICommon.hlsli"

Texture2D uiTexture : register(t0);
SamplerState uiSampler : register(s0);

float4 main(VertexOut vertIn) : SV_TARGET
{
    float4 color = uiTexture.Sample(uiSampler, vertIn.texCoord);
    return color * vertIn.color * tint;
}