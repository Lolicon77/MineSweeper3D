Shader "Unlit/Ground"
{
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
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
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_target
			{
				fixed2 t1 = step(fixed2(0.01,0.01),fmod(i.uv + fixed2(0.005,0.005),0.1));
				fixed3 c = t1.x * t1.y;
				fixed4 col = fixed4(c,1);
				return col;
			}
			ENDCG
		}
	}
}
