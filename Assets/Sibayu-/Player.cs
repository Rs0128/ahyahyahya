using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Vector3 playerPosition;
    public Image transitionPanel;
    public float transitionSpeed = 1.0f;

    void Start()
    {
        LoadPlayer();
        transitionPanel.CrossFadeAlpha(0, transitionSpeed, false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Eを押したらシーン切り替え
        {
            SavePlayer();

            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.R)) // Rを押したらシーン切り替え
        {
            SavePlayer();

            SceneManager.LoadScene(1);
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
    public void LoadScene(string sceneName)
    {
        // フェードアウト効果
        transitionPanel.CrossFadeAlpha(1, transitionSpeed, false);
        // シーンの読み込み
        SceneManager.LoadScene(sceneName);
    }
}