using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StaticMeshGen))]
public class StaticMeshGenEdior : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        StaticMeshGen script = (StaticMeshGen)target;
        if (GUILayout.Button("Generate Mesh"))
        {
            script.GenerateMesh();
        }
    }
}

public class StaticMeshGen : MonoBehaviour
{
    // Start is called before the first frame update
    public void GenerateMesh()
    {
        // mesh: 그물이란 뜻~(오브젝트를 만들어요)
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            //           X     Y     Z
            new Vector3(0.0f, 0.0f, 0.0f),
            new Vector3(1.0f, 0.0f, 0.0f),
            new Vector3(1.0f, 1.0f, 0.0f),
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


    // Update is called once per frame
    void Update()
    {
        
    }
}
