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

                // ���� ������ ���� ������ ������ ������ ��쿡�� �߰����� �����մϴ�.
                if (dot(normal, lightDir) > 0)
                {
                    diffuse += mid;
                }

                // �ܰ��� ������ ǥ���� ������ ������ �����Ƿ� �ܼ��� �ܰ��� ������ ����մϴ�.
                float3 outlineColor = _OutlineColor.rgb;

                float3 result = (diffuse + outlineColor);
                return float4(result, 1.0);
            }
            ENDCG
        }
    }
}

//Shader "Unlit/NewUnlitShader" // ��~
//{
//    Properties
//    {
//        _DiffuseColor("DiffuseColor", Color) = (1,1,1,1) // Ȯ�걤
//        _OutlineColor("OutlineColor", Color) = (0,0,0,1) // �ܰ��� ����
//        _OutlineWidth("OutlineWidth", Range(0.0, 0.1)) = 0.05 // �ܰ��� �β�
//        _LightDirection("LightDirection", Vector) = (1,-1,-1,0)
//        _Shininess("Shininess", Range(0.1, 256)) = 32 // ���� ����
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
//                float2 uv : TEXCOORD1; // UV ��ǥ �߰�
//            };
//
//            float4 _DiffuseColor;
//            float4 _OutlineColor;
//            float _OutlineWidth;
//            float3 _LightDirection;
//            sampler2D _OutlineSampler; // �ܰ��� ������ ���ø��� ���÷�
//            float _Shininess; // ���� ���� ���� ����
//
//            v2f vert(appdata v)
//            {
//                v2f o;
//                o.vertex = UnityObjectToClipPos(v.vertex);
//                o.normal = v.normal;
//                o.viewDir = normalize(_WorldSpaceCameraPos - v.vertex);
//                o.uv = v.vertex.xy; // UV ��ǥ ����
//                return o;
//            }
//
//            fixed4 frag(v2f i) : SV_Target
//            {
//                float3 normal = normalize(i.normal);
//                float3 viewDir = normalize(i.viewDir);
//                float3 lightDir = normalize(_LightDirection); // ���� ������ ���
//
//                // Ȯ�걤 ���
//                float diff = max(dot(normal, lightDir), 0.0);
//                float3 diffuse = _DiffuseColor.rgb * diff;
//
//                // �ݻ籤 ���
//                float3 reflectDir = reflect(-lightDir, normal);
//                float spec = max(dot(viewDir, reflectDir), 0.0);
//                spec = pow(spec, _Shininess);
//                float3 specular = _OutlineColor.rgb * spec;
//
//                // �ֺ� �� ���
//                float3 ambient = _OutlineColor.rgb;
//
//                float3 result = (ambient + diffuse + specular);
//                return float4(result, 1.0);
//            }
//            ENDCG
//        }
//    }
//}
