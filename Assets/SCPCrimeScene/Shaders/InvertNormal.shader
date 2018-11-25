 Shader "Custom/ShowInside" {
     Properties{
         _Color("Main Color", Color) = (1,1,1,1)
         _MainTex("Base (RGB)", 2D) = "white" {} 
     }
 
         SubShader{
         Tags{ "RenderType" = "Opaque" }  
         LOD 100
 
         Pass{
         Cull Front    
         Lighting Off
         SetTexture[_MainTex]{ combine texture }
         SetTexture[_MainTex]
             {
             ConstantColor[_Color]
             Combine Previous * Constant
             }
         }
     }
 }