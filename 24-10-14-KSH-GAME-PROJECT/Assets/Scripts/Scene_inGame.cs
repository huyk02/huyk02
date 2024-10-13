using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrans : MonoBehaviour
{
    public string InGameSceneName = "InGameScene"; // 인게임 씬의 이름

    public void InGame()
    {
        SceneManager.LoadScene(InGameSceneName);
    }

}