using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera mainCamera;
    public float moveSpeed = 10.0f;
    bool isRotating = false;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;
        forward.y = 0;
        right.y = 0;

        Vector3 move = forward * verticalInput + right * horizontalInput;
        transform.Translate(move * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.O) && !isRotating)
        {
            StartCoroutine(RotateCamera(-90.0f, 1.0f)); // 왼쪽으로 90도 회전
        }
        else if (Input.GetKeyDown(KeyCode.P) && !isRotating)
        {
            StartCoroutine(RotateCamera(90.0f, 1.0f)); // 오른쪽으로 90도 회전
        }
    }

    IEnumerator RotateCamera(float angle, float duration)
    {
        isRotating = true;
        Quaternion startRotation = mainCamera.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(mainCamera.transform.eulerAngles + Vector3.up * angle);

        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            mainCamera.transform.RotateAround(transform.position, Vector3.up, angle * Time.deltaTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.rotation = endRotation;
        isRotating = false;
        //mainCamera.transform.RotateAround(transform.position, Vector3.up, angle);
    }
}