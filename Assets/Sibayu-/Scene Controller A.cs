using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAController : MonoBehaviour
{
    public GameObject player; // プレイヤーオブジェクト

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 遷移前の座標を保存
            Vector3 playerPosition = player.transform.position;
            PlayerPrefs.SetFloat("PlayerPosX", playerPosition.x);
            PlayerPrefs.SetFloat("PlayerPosY", playerPosition.y);
            PlayerPrefs.SetFloat("PlayerPosZ", playerPosition.z);

            // シーン遷移
            SceneManager.LoadScene("KAITO");
        }
    }
}
