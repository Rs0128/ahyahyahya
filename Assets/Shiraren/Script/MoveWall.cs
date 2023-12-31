using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float moveSpeed = 2.0f; // 壁の移動速度
    public float minZ = 30.0f; // 移動する範囲の下限Z座標
    public float maxZ = 62.0f; // 移動する範囲の上限Z座標

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