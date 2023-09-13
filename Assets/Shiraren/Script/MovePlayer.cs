using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f; // �ړ����x�̐ݒ�
     Rigidbody rb;
     Transform playerCamera;

    [SerializeField] float jumpPower = 7f;
     bool Grounded = true;
     bool Jump = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main.transform;
    }


    void Update()
    {
        Vector3 cameraForward = playerCamera.forward;
        Vector3 cameraRight = playerCamera.right;

        // �����E�������͂��擾
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // �J�����̌����ňړ��x�N�g�����v�Z
        Vector3 movement = (cameraForward * verticalInput + cameraRight * horizontalInput) * moveSpeed;

        // �ړ��x�N�g����ݒ肵��Velocity���X�V
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        if (Grounded && Jump && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
            Jump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = true;
            Jump = true;
        }
    }

}
