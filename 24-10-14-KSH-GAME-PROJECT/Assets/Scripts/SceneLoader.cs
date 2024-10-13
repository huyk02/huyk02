using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadOrcBase()
    {
        SceneManager.LoadScene("Orc base");
    }

    public void LoadHumanBase()
    {
        SceneManager.LoadScene("Human base");
    }
}