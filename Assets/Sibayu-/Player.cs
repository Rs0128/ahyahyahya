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
        if (Input.GetKeyDown(KeyCode.E)) // E����������V�[���؂�ւ�
        {
            SavePlayer();

            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.R)) // R����������V�[���؂�ւ�
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
        // �t�F�[�h�A�E�g����
        transitionPanel.CrossFadeAlpha(1, transitionSpeed, false);
        // �V�[���̓ǂݍ���
        SceneManager.LoadScene(sceneName);
    }
}