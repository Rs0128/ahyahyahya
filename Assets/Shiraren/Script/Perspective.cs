using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float verticalLimit = 90f;

    private float verticalRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // êÖïΩâÒì]
        float horizontalRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(0f, horizontalRotation, 0f);

        // êÇíºâÒì]
        float verticalRotationInput = Input.GetAxis("Mouse Y") * rotationSpeed;
        verticalRotation -= verticalRotationInput;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLimit, verticalLimit);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
