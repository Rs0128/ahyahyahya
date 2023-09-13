using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float moveSpeed = 2.0f; // �ǂ̈ړ����x
    public float minZ = 30.0f; // �ړ�����͈͂̉���Z���W
    public float maxZ = 62.0f; // �ړ�����͈͂̏��Z���W

    private Vector3 startingPosition;
    private Vector3 targetPosition;

    void Start()
    {
        startingPosition = transform.position;
        targetPosition = new Vector3(startingPosition.x, startingPosition.y, minZ);
    }

    void Update()
    {
        Vector3 newPosition = Vector3.Lerp(startingPosition, targetPosition, Mathf.PingPong(Time.time * moveSpeed, 1.0f));
        transform.position = newPosition;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
        }
    }
}