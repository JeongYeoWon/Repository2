using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 오브젝트 풀링
    public GameObject bulletPrefab; // 총알 프리팹 설정
    public Transform spawnPoint; // 스팟 포인트~
    public Transform target; // 빨간박스랑 충돌 감지할 변수
    /*private LinkedList.Node<GameObject>.Queue<GameObject> bulletQueue
            = new LinkedList.Node<GameObject>.Queue<GameObject>(); // 총알을 저장할 큐*/
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
        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭 시
        {
            GameObject bullet = GetBullet(); // 사용 가능한 총알 가져오기
            if (bullet != null)
            {
                bullet.transform.position = spawnPoint.position; // 총알의 위치 설정
                bullet.SetActive(true); // 총알 활성화
                                        // 총알 발사 관련 로직 추가
            }
        }
    }

    static private GameObject CreateNewObject() // 총알 생성
    {
        // 총알을 생성하고 큐에 추가
        var newBullet = Instantiate(Instance.bulletPrefab, Instance.spawnPoint.position, Quaternion.identity);
        newBullet.gameObject.SetActive(false);
        return newBullet;
    }

    private void Initialize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            bulletStack.Push(CreateNewObject()); // 스택에 생성된 총알 추가
        }
    }

    public static GameObject GetBullet()
    {
        /*if (Instance.bulletQueue.Count() > 0) //현재 큐에 남아있는 오브젝트가 있다면,
        {
            var objectInPool = Instance.bulletQueue.Dequeue();

            objectInPool.SetActive(true);
            objectInPool.transform.SetParent(null);
            return objectInPool;
        }
        else //큐에 남아있는 오브젝트가 없을 때 새로 만들어서 사용
        {
            var objectInPool = Instance.CreateNewObject(); // 새로운 총알을 생성

            // 새로 생성한 총알을 꺼내서 반환
            objectInPool.SetActive(true);
            objectInPool.transform.SetParent(null);
            return objectInPool;
        }*/

        // 스택에서 총알 가져오기
        GameObject bullet = Instance.bulletStack.Pop();
        if (bullet != null)
        {
            bullet.SetActive(true); // 총알 활성화
            bullet.transform.SetParent(null); // 부모 설정
        }
        else
        {
            bullet = CreateNewObject(); // 새로운 총알 생성
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