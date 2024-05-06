using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static UnityEngine.GraphicsBuffer;
using UnityEditor;

[CustomEditor(typeof(MapHGenerator))]
public class MazeGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MapHGenerator generator = (MapHGenerator)target;

        if (GUILayout.Button("Preload Prefabs"))
        {
            generator.GenerateMaze();
        }
    }
}
public class MapHGenerator : MonoBehaviour
{
    public Transform terrain;
    public GameObject wallPrefab;
    public GameObject doorPrefab;

    public string filePath = "Assets/map.csv";

    void Start()
    {

    }

    public void GenerateMaze()
    {
        string[] lines = File.ReadAllLines(filePath);

        Vector3 terrainPos = terrain.position;

        Vector3 wallSize = wallPrefab.GetComponent<Renderer>().bounds.size;
        Vector3 doorSize = doorPrefab.GetComponent<Renderer>().bounds.size;

        for (int y = 0; y < lines.Length; y++)
        {
            string line = lines[y];
            string[] cells = line.Split(',');

            for (int x = 0; x < cells.Length; x++)
            {
                int cellType = int.Parse(cells[x]);

                Vector3 position = terrainPos + new Vector3(x * wallSize.x, 0, -y * wallSize.z);

                if (cellType == 0)
                {
                }
                else if (cellType == 1)
                {
                    Instantiate(doorPrefab, position, Quaternion.identity);
                }
                else if (cellType == 2)
                {
                    Instantiate(wallPrefab, position, Quaternion.identity);
                }
            }
        }
    }
}
