Shader "SolidColorWithZTest"
{
	Properties
	{
		_Color1("Color1", Color) = (1,1,1,0.4)
		_Color2("Color2", Color) = (1,1,1,1)
	}
		SubShader
	{
		Tags{ "Queue" = "Geometry+1" "RenderType" = "Transparent" }
		Pass
		{
			ZTest Greater
			Color[_Color1]

		}
		Pass
		{
			ZTest Less
			Color[_Color2]
		}
	}
}