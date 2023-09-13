using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Vector3 teleportPosition = new Vector3(0.0f, 1.3f, 26.0f); // テレポート先の座標

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Teleport();
        }
    }

    void Teleport()
    {
        transform.position = teleportPosition;
    }
}
