using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrans : MonoBehaviour
{
    public string InGameSceneName = "InGameScene"; // �ΰ��� ���� �̸�

    public void InGame()
    {
        SceneManager.LoadScene(InGameSceneName);
    }

}