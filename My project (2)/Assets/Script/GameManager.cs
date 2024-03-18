using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹 설정
    public Transform spawnPoint; // 스팟 포인트~
    public Transform target; // 빨간박스랑 충돌 감지할 변수
    private QueueBullet.Node<GameObject>.Queue<GameObject> bulletQueue; // 총알을 저장할 큐
    // Start is called before the first frame update
    void Start()
    {
        // 큐 객체 생성
        bulletQueue = new QueueBullet.Node<GameObject>.Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭 시
        {
            SpawnBullet(); // 총알 뿅뿅
        }
    }
    void SpawnBullet() // 총알 생성
    {
        if (bulletQueue.helpme(10)) // 총알이 10개 미만이면
        {
            // 총알을 생성하고 큐에 추가
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            bulletQueue.Enqueue(newBullet);
            
        }
    }
}