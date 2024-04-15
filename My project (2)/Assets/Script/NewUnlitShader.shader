Shader "Unlit/ToonShaderWithMidColor"
{
    Properties
    {
        _DiffuseColor("Diffuse Color", Color) = (1,1,1,1)
        _OutlineColor("Outline Color", Color) = (0,0,0,1)
        _MidColor("Mid Color", Color) = (0.5, 0.5, 0.5, 1)
        _OutlineWidth("Outline Width", Range(0.0, 0.1)) = 0.05
        _LightDirection("Light Direction", Vector) = (1,-1,-1,0)
        _Shininess("Shininess", Range(0.1, 256)) = 32
    }

        SubShader
    {
        Tags { "RenderType" = "Opaque" }
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
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 normal : NORMAL;
                float3 viewDir : TEXCOORD0;
                float2 uv : TEXCOORD1;
            };

            float4 _DiffuseColor;
            float4 _OutlineColor;
            float4 _MidColor;
            float _OutlineWidth;
            float3 _LightDirection;
            float _Shininess;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                o.viewDir = normalize(_WorldSpaceCameraPos - v.vertex);
                o.uv = v.vertex.xy;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float3 normal = normalize(i.normal);
                float3 viewDir = normalize(i.viewDir);
                float3 lightDir = normalize(_LightDirection);

                float diff = max(dot(normal, lightDir), 0.0);
                diff = floor(diff * 2) / 2;

                float3 diffuse = _DiffuseColor.rgb * diff;
                float3 mid = _MidColor.rgb;

                // 빛의 각도와 법선 사이의 내적이 음수인 경우에만 중간색을 적용합니다.
                if (dot(normal, lightDir) > 0)
                {
                    diffuse += mid;
                }

                // 외곽선 색상은 표면의 법선과 관련이 있으므로 단순히 외곽선 색상을 사용합니다.
                float3 outlineColor = _OutlineColor.rgb;

                float3 result = (diffuse + outlineColor);
                return float4(result, 1.0);
            }
            ENDCG
        }
    }
}

//Shader "Unlit/NewUnlitShader" // 퐁~
//{
//    Properties
//    {
//        _DiffuseColor("DiffuseColor", Color) = (1,1,1,1) // 확산광
//        _OutlineColor("OutlineColor", Color) = (0,0,0,1) // 외곽선 색상
//        _OutlineWidth("OutlineWidth", Range(0.0, 0.1)) = 0.05 // 외곽선 두께
//        _LightDirection("LightDirection", Vector) = (1,-1,-1,0)
//        _Shininess("Shininess", Range(0.1, 256)) = 32 // 광택 정도
//    }
//        SubShader
//    {
//        Tags { "RenderType" = "Opaque" }
//        LOD 100
//
//        Pass
//        {
//            CGPROGRAM
//            #pragma vertex vert
//            #pragma fragment frag
//            // make fog work
//
//            #include "UnityCG.cginc"
//
//            struct appdata
//            {
//                float4 vertex : POSITION;
//                float3 normal : NORMAL;
//            };
//
//            struct v2f
//            {
//                float4 vertex : SV_POSITION;
//                float3 normal : NORMAL;
//                float3 viewDir : TEXCOORD0;
//                float2 uv : TEXCOORD1; // UV 좌표 추가
//            };
//
//            float4 _DiffuseColor;
//            float4 _OutlineColor;
//            float _OutlineWidth;
//            float3 _LightDirection;
//            sampler2D _OutlineSampler; // 외곽선 색상을 샘플링할 샘플러
//            float _Shininess; // 광택 정도 변수 선언
//
//            v2f vert(appdata v)
//            {
//                v2f o;
//                o.vertex = UnityObjectToClipPos(v.vertex);
//                o.normal = v.normal;
//                o.viewDir = normalize(_WorldSpaceCameraPos - v.vertex);
//                o.uv = v.vertex.xy; // UV 좌표 설정
//                return o;
//            }
//
//            fixed4 frag(v2f i) : SV_Target
//            {
//                float3 normal = normalize(i.normal);
//                float3 viewDir = normalize(i.viewDir);
//                float3 lightDir = normalize(_LightDirection); // 빛의 방향을 사용
//
//                // 확산광 계산
//                float diff = max(dot(normal, lightDir), 0.0);
//                float3 diffuse = _DiffuseColor.rgb * diff;
//
//                // 반사광 계산
//                float3 reflectDir = reflect(-lightDir, normal);
//                float spec = max(dot(viewDir, reflectDir), 0.0);
//                spec = pow(spec, _Shininess);
//                float3 specular = _OutlineColor.rgb * spec;
//
//                // 주변 광 계산
//                float3 ambient = _OutlineColor.rgb;
//
//                float3 result = (ambient + diffuse + specular);
//                return float4(result, 1.0);
//            }
//            ENDCG
//        }
//    }
//}
