using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string DeckName = "Deck"; // 인게임 씬의 이름

    public void InGame()
    {
        SceneManager.LoadScene(DeckName);
    }

}