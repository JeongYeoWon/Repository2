using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEditor;

[CustomEditor(typeof(Shadermesh))]
public class ShaderEditor : Editor
{
    //��ư����� ����
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

        /*// ����� ����� ���� �迭 ����
        List<Vector3> verticesList = new List<Vector3>();
        int numPoints = 5; // ���� ������ ����
        float radius1 = 0.5f; // �߽ɿ��� �������������� �Ÿ�
        float radius2 = 0.25f; // ������� ��Ÿ���� �Ÿ�
        for (int i = 0; i < numPoints * 2; i++)
        {
            float radius = i % 2 == 0 ? radius1 : radius2;
            float angle = Mathf.PI * 2 * i / (numPoints * 2);
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            verticesList.Add(new Vector3(x, y, 0f));
        }
        verticesList.Add(Vector3.zero); // �߽��� �߰�
        Vector3[] vertices = verticesList.ToArray();

        mesh.vertices = vertices;

        // �ﰢ�� �迭 ����
        List<int> trianglesList = new List<int>();
        for (int i = 0; i < numPoints * 2; i++)
        {
            int nextIndex = (i + 1) % (numPoints * 2);
            trianglesList.Add(i);
            trianglesList.Add(nextIndex);
            trianglesList.Add(numPoints * 2);
        }
        mesh.triangles = trianglesList.ToArray();*/

        /*// ����� ����� ���� �迭 ����
        List<Vector3> verticesList = new List<Vector3>();
        int numPoints = 5; // ���� ������ ����
        float radius1 = 0.5f; // �߽ɿ��� �������������� �Ÿ�
        float radius2 = 0.25f; // ������� ��Ÿ���� �Ÿ�
        float height = 1f; // ������� ����
        // ���� �� ������ ����
    for (int i = 0; i < numPoints * 2; i++)
    {
        float radius = i % 2 == 0 ? radius1 : radius2;
        float angle = Mathf.PI * 2 * i / (numPoints * 2);
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        verticesList.Add(new Vector3(x, y, 0f)); // �Ʒ����� ����
        verticesList.Add(new Vector3(x, y, height)); // ������ ����
    }
    verticesList.Add(verticesList[0]); // ���� ������ �ٽ� �߰��Ͽ� ������� ����

    Vector3[] vertices = verticesList.ToArray();

    // �ﰢ�� �迭 ����
    List<int> trianglesList = new List<int>();
    for (int i = 0; i < numPoints * 2; i += 2)
    {
        // �Ʒ��� �ﰢ��
        trianglesList.Add(i);
        trianglesList.Add(i + 2);
        trianglesList.Add(numPoints * 2);

        // ���� �ﰢ��
        trianglesList.Add(i + 1);
        trianglesList.Add(numPoints * 2 + 1);
        trianglesList.Add(i + 3);

        // ���� �ﰢ��
        trianglesList.Add(i);
        trianglesList.Add(i + 1);
        trianglesList.Add(i + 3);

        trianglesList.Add(i);
        trianglesList.Add(i + 3);
        trianglesList.Add(i + 2);
    }

    mesh.vertices = vertices;
    mesh.triangles = trianglesList.ToArray();*/

        // ����� ����� ���� �迭 ����
        List<Vector3> verticesList = new List<Vector3>();
        List<Vector3> verticesList2 = new List<Vector3>();
        int numPoints = 5; // ���� ������ ����
        float radius1 = 0.5f; // �߽ɿ��� �������������� �Ÿ�
        float radius2 = 0.25f; // ������� ��Ÿ���� �Ÿ�
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
        verticesList.Add(Vector3.zero); // �߽��� �߰�

        // verticesList2�� ������ �ٲپ� ������� �����ϵ��� ����
        for (int i = numPoints - 1; i >= 0; i--)
        {
            verticesList.Add(verticesList2[i]);
        }

        Vector3[] vertices = verticesList.ToArray();
        mesh.vertices = vertices;

        // �ﰢ�� �迭 ����
        List<int> trianglesList = new List<int>();
        int numVertices = numPoints * 2;
        for (int i = 0; i < numPoints; i++)
        {
            int nextIndex = (i + 1) % numPoints;

            // �Ʒ��� �ﰢ��
            trianglesList.Add(i);
            trianglesList.Add(nextIndex);
            trianglesList.Add(numVertices);

            // ���� �ﰢ��
            trianglesList.Add(i + numPoints);
            trianglesList.Add(numVertices + 1);
            trianglesList.Add(nextIndex + numPoints);

            // ���� �ﰢ��
            trianglesList.Add(i);
            trianglesList.Add(i + numPoints);
            trianglesList.Add(nextIndex);

            trianglesList.Add(nextIndex + numPoints);
            trianglesList.Add(nextIndex);
            trianglesList.Add(i + numPoints);
        }

        mesh.triangles = trianglesList.ToArray();


        // MeshFilter�� MeshRenderer �������� (������ �߰�)
        MeshFilter mf = gameObject.GetComponent<MeshFilter>();
        if (mf == null)
            mf = gameObject.AddComponent<MeshFilter>();

        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        if (mr == null)
            mr = gameObject.AddComponent<MeshRenderer>();

        // ���ο� ��Ƽ���� ���� �� ���� ����
        Material material = new Material(Shader.Find("Standard"));
        material.color = Color.yellow; // ��������� ����

        // MeshRenderer�� ��Ƽ���� ����
        mr.sharedMaterial = material;
        /*MeshFilter mf = this.AddComponent<MeshFilter>();
        MeshRenderer mr = this.AddComponent<MeshRenderer>();*/
    }
    // Update is called once per frame
    void Update()
    {

    }
}