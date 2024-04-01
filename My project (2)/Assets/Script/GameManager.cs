using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // ������Ʈ Ǯ��
    public GameObject bulletPrefab; // �Ѿ� ������ ����
    public Transform spawnPoint; // ���� ����Ʈ~
    public Transform target; // �����ڽ��� �浹 ������ ����
    /*private LinkedList.Node<GameObject>.Queue<GameObject> bulletQueue
            = new LinkedList.Node<GameObject>.Queue<GameObject>(); // �Ѿ��� ������ ť*/
    LinkedList<GameObject> bulletStack;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null) Instance = this;
        bulletStack = new LinkedList<GameObject>();
        Initialize(10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ��Ŭ�� ��
        {
            GameObject bullet = GetBullet(); // ��� ������ �Ѿ� ��������
            if (bullet != null)
            {
                bullet.transform.position = spawnPoint.position; // �Ѿ��� ��ġ ����
                bullet.SetActive(true); // �Ѿ� Ȱ��ȭ
                                        // �Ѿ� �߻� ���� ���� �߰�
            }
        }
    }

    static private GameObject CreateNewObject() // �Ѿ� ����
    {
        // �Ѿ��� �����ϰ� ť�� �߰�
        var newBullet = Instantiate(Instance.bulletPrefab, Instance.spawnPoint.position, Quaternion.identity);
        newBullet.gameObject.SetActive(false);
        return newBullet;
    }

    private void Initialize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            bulletStack.Push(CreateNewObject()); // ���ÿ� ������ �Ѿ� �߰�
        }
    }

    public static GameObject GetBullet()
    {
        /*if (Instance.bulletQueue.Count() > 0) //���� ť�� �����ִ� ������Ʈ�� �ִٸ�,
        {
            var objectInPool = Instance.bulletQueue.Dequeue();

            objectInPool.SetActive(true);
            objectInPool.transform.SetParent(null);
            return objectInPool;
        }
        else //ť�� �����ִ� ������Ʈ�� ���� �� ���� ���� ���
        {
            var objectInPool = Instance.CreateNewObject(); // ���ο� �Ѿ��� ����

            // ���� ������ �Ѿ��� ������ ��ȯ
            objectInPool.SetActive(true);
            objectInPool.transform.SetParent(null);
            return objectInPool;
        }*/

        // ���ÿ��� �Ѿ� ��������
        GameObject bullet = Instance.bulletStack.Pop();
        if (bullet != null)
        {
            bullet.SetActive(true); // �Ѿ� Ȱ��ȭ
            bullet.transform.SetParent(null); // �θ� ����
        }
        else
        {
            bullet = CreateNewObject(); // ���ο� �Ѿ� ����
        }
        return bullet;
    }
    public static void ReturnObject(GameObject bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(Instance.transform);
        /*Instance.bulletQueue.Enqueue(bullet);*/
        Instance.bulletStack.Push(bullet);
    }
}