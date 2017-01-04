Shader "Unlit/SimpleEdge"
{
	Properties
	{
		_MainColor ("MainColor", Color) = (0,0,0,1)
		_EdgeColor ("EdgeColor", Color) = (1,1,1,1)
		_EdgeWidth ("EdgeWidth",Range(0,0.5)) = 0.05
	}
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
				float2 uv     : TEXCOORD0; 
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv     : TEXCOORD0; 
			};

			uniform fixed4 _MainColor;
			uniform fixed4 _EdgeColor;
			uniform fixed _EdgeWidth;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP,v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				int test = step(i.uv.x,_EdgeWidth);
				int temp = step(1 - _EdgeWidth,i.uv.x);
				test = test|temp;
				temp = step(i.uv.y,_EdgeWidth);
				test = test|temp;
				temp = step(1 - _EdgeWidth,i.uv.y);
				test = test|temp;

				fixed4 col = lerp(_EdgeColor,_MainColor,test);
				return col;
			}
			ENDCG
		}
	}
}
