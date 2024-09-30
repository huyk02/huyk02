using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    void Update()
    {
        // 마우스 클릭 시 Loading 씬으로 전환
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 클릭
        {
            SceneManager.LoadScene("Loading"); // "Loading" 씬 이름을 씬에 맞게 설정
        }
    }
}
