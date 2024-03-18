using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 5f; // 총알 이동 속도
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
