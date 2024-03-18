using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HELP : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    // 충돌 감지 시 호출되는 함수
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) // 빨간 상자와 충돌했는지 확인
        {
            GameObject bullet = other.gameObject; // 충돌한 객체가 총알인지 확인
            Destroy(bullet); // 그리고 삭제
        }
    }
}
