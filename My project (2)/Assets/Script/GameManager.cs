using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bulletPrefab; // �Ѿ� ������ ����
    public Transform spawnPoint; // ���� ����Ʈ~
    public Transform target; // �����ڽ��� �浹 ������ ����
    private QueueBullet.Node<GameObject>.Queue<GameObject> bulletQueue; // �Ѿ��� ������ ť
    // Start is called before the first frame update
    void Start()
    {
        // ť ��ü ����
        bulletQueue = new QueueBullet.Node<GameObject>.Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ��Ŭ�� ��
        {
            SpawnBullet(); // �Ѿ� �л�
        }
    }
    void SpawnBullet() // �Ѿ� ����
    {
        if (bulletQueue.helpme(10)) // �Ѿ��� 10�� �̸��̸�
        {
            // �Ѿ��� �����ϰ� ť�� �߰�
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            bulletQueue.Enqueue(newBullet);
            
        }
    }
}