using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 5f; // �Ѿ� �̵� �ӵ�
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
