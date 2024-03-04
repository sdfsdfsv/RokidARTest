Shader "Flag2D"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _UVRect("UVRect", Vector) = (0,0,1,1)
        _Color ("Color", Color) = (255,255,255,255)
    }
    SubShader
    {
        Tags {
        "RenderType"="Transparent"
        "CanUseSpriteAtlas"="True" }
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha // Enable alpha blending
            CGPROGRAM
            #pragma vertex vert
            #pragma exclude_renderers gles xbox360 ps3
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            struct appdata_t
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float _RoundWidth;
            float4 _UVRect;
            float4 _Color;

            float hash(float2 co){
                return frac(sin(dot(co ,float2(12.9898, 78.233))) * 43758.5453);
            }

            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                
                o.uv = v.vertex.xy;
                return o;
            }

            #define PI 3.1415926535

            fixed4 frag(v2f i) : COLOR
            {   
                
                

                // Normalize the UV coordinates within the specified UVRect
                float2 uv = (i.uv - _UVRect.xy) / (_UVRect.z - _UVRect.x);

                uv*=2.;
                
                float2 st = ((i.uv - _UVRect.xy)+float2(.5,.5)*(_UVRect.zw - _UVRect.xy)) / min((_UVRect.z - _UVRect.x),(_UVRect.w - _UVRect.y)) ;
                st.x/=1.5;
                float2 ouv = uv;

                // Sample the texture
                fixed4 col = tex2D(_MainTex, st);

                float w = sin((uv.x + uv.y - _Time.y * .75 + sin(3 * uv.x + 9 * uv.y) * PI * .3)
                            * PI * .6); // fake waviness factor
                
                uv *= 1. + (.036 - .036 * w*pow(1.3,(1.-st.y)));
                
            
                col += w * .225;
                
                float v = 16. * st.x * (1. - st.x) * st.y * (1. - st.y); // vignette
                col *= 1. - .2 * exp2(-.05 * v);
                col = clamp(col - hash(uv) * .004, 0., 1.);

                col.a *= 1.-1.*length(float2(ouv.x,ouv.y));

                col.a = pow(col.a,-.1);
                float val = 1;
                // col.a *= smoothstep(0,val,1-abs(1-st.y))/val;
                val = 1 ;
                col.a *= smoothstep(0.,val,.8-abs(.8-st.x))/val;
                col *= tex2D(_MainTex, st);
                return col;
            }

            ENDCG
        }
    }
}
