using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Unity.VisualScripting;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(helpme))]
public class MeshS : Editor
{
    //버튼만들기 예제
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        helpme script = (helpme)target;

        if (GUILayout.Button("Generate Mesh"))
        {
            script.GenerateMesh();
        }

    }
}
public class helpme : MonoBehaviour
{
    // Start is called before the first frame update
    public void GenerateMesh()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
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

        mesh.triangles = triangleIndices;

        MeshFilter mf = this.AddComponent<MeshFilter>();
        MeshRenderer mr = this.AddComponent<MeshRenderer>();

        mf.mesh = mesh;
    }
}