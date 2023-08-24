// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Slit" {
    Properties {
        _MainTex ("Source", 2D) = "white" {}
        _Size ("Size", Float) = 1
        _AnimTime ("Animation Time", Range(0,1)) = 0
    }
    SubShader {
        ZTest Always
        Cull Off
        ZWrite Off
        Fog { Mode Off }

        Pass{
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata_img v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = MultiplyUV(UNITY_MATRIX_TEXTURE0, v.texcoord.xy);
                return o;
            }

            sampler2D _MainTex;
            float _Size;
            float _AnimTime;

            fixed4 frag(v2f i) : SV_TARGET {
                float delta = _Size / _ScreenParams.x;
                float visible = 1.0 - floor(frac(i.uv.x / delta) + _AnimTime);

                return fixed4(tex2D(_MainTex, i.uv).rgb * visible, 1.0);
            }
            ENDCG
        }
    }
    FallBack Off
}