Shader "Custom/BorderShader"
{
    Properties
    {
        _MainColor ("Main Color", Color) = (1,1,1,1)
        _EdgeColor ("Edge Color", Color) = (0,0,0,1)
        _EdgeWidth ("Edge Width", float) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        Pass
        {
            Cull Off 
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 _MainColor;
            float4 _EdgeColor;
            float _EdgeWidth;

            float4 frag (v2f i) : SV_Target
            {
                // Calculate edge condition
                bool isEdge = i.uv.x < _EdgeWidth || i.uv.y < _EdgeWidth || i.uv.x > 1.0 - _EdgeWidth || i.uv.y > 1.0 - _EdgeWidth;

                // Select color based on edge condition
                return isEdge ? _EdgeColor : _MainColor;
            }
            ENDCG
        }
    }
}
