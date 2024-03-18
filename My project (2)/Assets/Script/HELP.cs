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
    // �浹 ���� �� ȣ��Ǵ� �Լ�
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) // ���� ���ڿ� �浹�ߴ��� Ȯ��
        {
            GameObject bullet = other.gameObject; // �浹�� ��ü�� �Ѿ����� Ȯ��
            Destroy(bullet); // �׸��� ����
        }
    }
}
