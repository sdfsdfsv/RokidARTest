Shader "UI/ScanlineShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _MainColor ("Main Color", Color) = (1,1,1,1)
        _LineColor ("Line Color", Color) = (1,1,1,1)
        _LineWidth ("Line Width", Float) = 0.1
        _LineSpacing ("Line Spacing", Float) = 10.0
        _AnimationSpeed("Animation Speed", Float) = 10.
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityUI.cginc"

            fixed4 _MainColor;
            fixed4 _LineColor;

            float _LineWidth;
            float _LineSpacing;
            float _AnimationSpeed;
            sampler2D _MainTex;
            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                fixed4 color : COLOR;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.uv = IN.uv;
                OUT.color = IN.color;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                fixed4 color = tex2D(_MainTex, IN.uv);
                if(color.a > 0){
                    color = _MainColor;
                }
                float lineFactor = sin((IN.uv.y-_Time.y*_AnimationSpeed) / _LineSpacing*_ScreenParams )+1.;
                lineFactor/=2.;
                lineFactor = smoothstep(0.5 - _LineWidth, 0.5 + _LineWidth, lineFactor);
                
                lineFactor = clamp(pow(lineFactor,0.4),0,1);

                // lineFactor = lineFactor* pow( abs(IN.uv.y-0.5) , .1);
                color.rgb = lerp(color.rgb, _LineColor.rgb, lineFactor);
                
               

                return color;
            }
            ENDCG
        }
    }
}