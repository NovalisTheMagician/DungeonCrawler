#include "UICommon.hlsli"

Texture2D uiTexture;
SamplerState uiSampler;

float4 main(VertexOut vertIn) : SV_TARGET
{
    float4 color = uiTexture.Sample(uiSampler, vertIn.texCoord);
    return color * vertIn.color;
}