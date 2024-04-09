Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        // ���� �����̱���.
        _DiffuseColor("DiffuseColor", Color) = (1,1,1,1) // Ȯ�걤
        _SpecularColor("SpecularColor", Color)=(1,1,1,1) // �ݻ籤
        _AmbientColor("AmbientColor", Color)=(1,1,1,1) // �ֺ�?��
        _Shininess("Shininess", Range(0.1, 256))=32
        _LightDirection("LightDirection", Vector) = (1,-1,-1,0)

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
            // make fog work

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float3 viewDir : TEXCOORD0;
            };

            float4 _DiffuseColor;
            float3 _LightDirection;

            float4 _SpecularColor;
            float4 _AmbientColor;
            float2 _Shininess;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                o.viewDir = normalize(_WorldSpaceCameraPos - v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 normal = normalize(i.normal);
                float3 viewDir = normalize(i.viewDir);
                float3 lightDir = normalize(_LightDirection);

                // Ȯ�걤 ���
                float diff = max(dot(normal, lightDir), 0.0);
                float3 diffuse = _DiffuseColor * diff;

                // �ݻ籤 ���
                float3 reflectDir = reflect(-lightDir, normal);
                float spec = max(dot(viewDir, reflectDir), 0.0);
                spec = pow(spec, _Shininess);
                float3 specular = _SpecularColor * spec;

                // �ֺ� �� ���
                float3 ambient = _AmbientColor;

                float3 result = (ambient + diffuse + specular);
                return float4(result, 1.0);
                // sample the texture
                //fixed4 col = float4(1.0f,1.0f,0.0,1.0f);
                /*float lightDir = normalize(_LightDirection);
                float lightIntensity = max(dot(i.normal,lightDir),0);

                float4 col = _DiffuseColor * lightIntensity;


                return col;*/
            }
            ENDCG
        }
    }
}
