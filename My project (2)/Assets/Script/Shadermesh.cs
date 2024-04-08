using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEditor;

[CustomEditor(typeof(Shadermesh))]
public class ShaderEditor : Editor
{
    //버튼만들기 예제
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Shadermesh script = (Shadermesh)target;

        if (GUILayout.Button("Generate Mesh"))
        {
            script.GenerateMesh();
        }

    }
}
public class Shadermesh : MonoBehaviour
{
    // Start is called before the first frame update
    public void GenerateMesh()
    {
        Mesh mesh = new Mesh();

        /*Vector3[] vertices = new Vector3[]
        {
        new Vector3 (0.0f, 0.0f, 0.0f),
        new Vector3 (1.0f, 0.0f, 0.0f),
        new Vector3 (1.0f, 1.0f, 0.0f),
        };

        mesh.vertices = vertices;

        int[] triangleIndices = new int[]
        {
        0,2,1,
        };

        mesh.triangles = triangleIndices;*/

        /*// 별기둥 모양의 정점 배열 생성
        List<Vector3> verticesList = new List<Vector3>();
        int numPoints = 5; // 별의 꼭짓점 개수
        float radius1 = 0.5f; // 중심에서 별꼭짓점까지의 거리
        float radius2 = 0.25f; // 별모양이 나타나는 거리
        for (int i = 0; i < numPoints * 2; i++)
        {
            float radius = i % 2 == 0 ? radius1 : radius2;
            float angle = Mathf.PI * 2 * i / (numPoints * 2);
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            verticesList.Add(new Vector3(x, y, 0f));
        }
        verticesList.Add(Vector3.zero); // 중심점 추가
        Vector3[] vertices = verticesList.ToArray();

        mesh.vertices = vertices;

        // 삼각형 배열 생성
        List<int> trianglesList = new List<int>();
        for (int i = 0; i < numPoints * 2; i++)
        {
            int nextIndex = (i + 1) % (numPoints * 2);
            trianglesList.Add(i);
            trianglesList.Add(nextIndex);
            trianglesList.Add(numPoints * 2);
        }
        mesh.triangles = trianglesList.ToArray();*/

        /*// 별기둥 모양의 정점 배열 생성
        List<Vector3> verticesList = new List<Vector3>();
        int numPoints = 5; // 별의 꼭짓점 개수
        float radius1 = 0.5f; // 중심에서 별꼭짓점까지의 거리
        float radius2 = 0.25f; // 별모양이 나타나는 거리
        float height = 1f; // 별기둥의 높이
        // 별의 각 꼭짓점 생성
    for (int i = 0; i < numPoints * 2; i++)
    {
        float radius = i % 2 == 0 ? radius1 : radius2;
        float angle = Mathf.PI * 2 * i / (numPoints * 2);
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        verticesList.Add(new Vector3(x, y, 0f)); // 아랫면의 정점
        verticesList.Add(new Vector3(x, y, height)); // 윗면의 정점
    }
    verticesList.Add(verticesList[0]); // 시작 정점을 다시 추가하여 별기둥을 닫음

    Vector3[] vertices = verticesList.ToArray();

    // 삼각형 배열 생성
    List<int> trianglesList = new List<int>();
    for (int i = 0; i < numPoints * 2; i += 2)
    {
        // 아랫면 삼각형
        trianglesList.Add(i);
        trianglesList.Add(i + 2);
        trianglesList.Add(numPoints * 2);

        // 윗면 삼각형
        trianglesList.Add(i + 1);
        trianglesList.Add(numPoints * 2 + 1);
        trianglesList.Add(i + 3);

        // 옆면 삼각형
        trianglesList.Add(i);
        trianglesList.Add(i + 1);
        trianglesList.Add(i + 3);

        trianglesList.Add(i);
        trianglesList.Add(i + 3);
        trianglesList.Add(i + 2);
    }

    mesh.vertices = vertices;
    mesh.triangles = trianglesList.ToArray();*/

        // 별기둥 모양의 정점 배열 생성
        List<Vector3> verticesList = new List<Vector3>();
        List<Vector3> verticesList2 = new List<Vector3>();
        int numPoints = 5; // 별의 꼭짓점 개수
        float radius1 = 0.5f; // 중심에서 별꼭짓점까지의 거리
        float radius2 = 0.25f; // 별모양이 나타나는 거리
        for (int i = 0; i < numPoints * 2; i++)
        {
            float radius = i % 2 == 0 ? radius1 : radius2;
            float angle = Mathf.PI * 2 * i / (numPoints * 2);
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            verticesList.Add(new Vector3(x, y, 0f));
            verticesList2.Add(new Vector3(x-0.2f, y+0.1f, 1f));
        }
        verticesList.AddRange(verticesList2);
        verticesList.Add(Vector3.zero); // 중심점 추가

        // verticesList2의 순서를 바꾸어 별모양을 유지하도록 조정
        for (int i = numPoints - 1; i >= 0; i--)
        {
            verticesList.Add(verticesList2[i]);
        }

        Vector3[] vertices = verticesList.ToArray();
        mesh.vertices = vertices;

        // 삼각형 배열 생성
        List<int> trianglesList = new List<int>();
        int numVertices = numPoints * 2;
        for (int i = 0; i < numPoints; i++)
        {
            int nextIndex = (i + 1) % numPoints;

            // 아랫면 삼각형
            trianglesList.Add(i);
            trianglesList.Add(nextIndex);
            trianglesList.Add(numVertices);

            // 윗면 삼각형
            trianglesList.Add(i + numPoints);
            trianglesList.Add(numVertices + 1);
            trianglesList.Add(nextIndex + numPoints);

            // 옆면 삼각형
            trianglesList.Add(i);
            trianglesList.Add(i + numPoints);
            trianglesList.Add(nextIndex);

            trianglesList.Add(nextIndex + numPoints);
            trianglesList.Add(nextIndex);
            trianglesList.Add(i + numPoints);
        }

        mesh.triangles = trianglesList.ToArray();


        // MeshFilter와 MeshRenderer 가져오기 (없으면 추가)
        MeshFilter mf = gameObject.GetComponent<MeshFilter>();
        if (mf == null)
            mf = gameObject.AddComponent<MeshFilter>();

        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        if (mr == null)
            mr = gameObject.AddComponent<MeshRenderer>();

        // 새로운 머티리얼 생성 및 색상 설정
        Material material = new Material(Shader.Find("Standard"));
        material.color = Color.yellow; // 노란색으로 설정

        // MeshRenderer에 머티리얼 설정
        mr.sharedMaterial = material;
        /*MeshFilter mf = this.AddComponent<MeshFilter>();
        MeshRenderer mr = this.AddComponent<MeshRenderer>();*/
    }
    // Update is called once per frame
    void Update()
    {

    }
}