using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Enemy))]
public class staticEnemy : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Enemy script = (Enemy)target;

        if (GUILayout.Button("Show Gizmos"))
        {
            script.InitialPos();
        }
    }
}
public class Enemy : MonoBehaviour
{
    Vector3 offset = new Vector3(0.0f, 0.0f, 3.75f);
    Vector3 boxSize = new Vector3(3.0f, 5.0f, 13.0f);
    float moveSpeed = 3f;
    Vector3 initialPosition;
    bool goMoving = true;

#if UNITY_EDITOR
    public void InitialPos()
    {
        GameObject enemyObject = GameObject.Find("Enemy");
        if (enemyObject != null)
        {
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.initialPosition = enemy.transform.position;
            }
        }
    }
#endif

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        Vector3 targetPosition = goMoving ?
        initialPosition + new Vector3(0.0f, 0.0f, boxSize.z / 1.5f) :
        initialPosition + new Vector3(0.0f, 0.0f, -boxSize.z / 15.75f);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            goMoving = !goMoving;
        }
    }
    public void OnDrawGizmos()
    {
        Vector3 gizmoPosition = initialPosition + offset;
        Handles.color = Color.yellow;
        Handles.DrawWireCube(gizmoPosition, boxSize);
            /*Matrix4x4 cubeTransform = Matrix4x4.TRS(initialPosition, Quaternion.identity, Vector3.one);

            using (new Handles.DrawingScope(cubeTransform))
            {
                Handles.DrawWireCube(offset, boxSize);
            }*/
        }
}