using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera mainCamera;
    public float moveSpeed = 5.0f;

    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        // 키 입력 감지
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;
        forward.y = 0;
        right.y = 0;

        Vector3 move = forward * verticalInput + right * horizontalInput;
        transform.Translate(move * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.O))
        {
            
        }
    }
}
