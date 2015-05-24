Shader "Custom/Cube"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "" {}
		_Texture2 ("Texture 2", 2D) = "" {}
		_Color ("Main Color", Color) = (1,1,1,1)
		_Blend ("Draw Texture 2", Range(0, 1)) = 0
	}
	SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
	    Blend SrcAlpha OneMinusSrcAlpha
	    LOD 200
	    ZWrite off
	    
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _Texture2;
		fixed4 _Color;
		float _Blend;

		struct Input
		{
			float2 uv_MainTex;
		};
	
	
		void surf (Input IN, inout SurfaceOutput o)
		{
			half4 mainTex = tex2D (_MainTex, IN.uv_MainTex);
			half4 tex2 = tex2D (_Texture2, IN.uv_MainTex) * _Blend;
			
			o.Albedo = mainTex.rgb * (mainTex.a - tex2.a) + tex2.rgb * tex2.a * mainTex.rgb;
      		o.Alpha = _Color.a * mainTex.a;
		}
		ENDCG
	}
}
