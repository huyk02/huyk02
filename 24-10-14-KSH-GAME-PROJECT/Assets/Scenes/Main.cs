using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    void Update()
    {
        // ���콺 Ŭ�� �� Loading ������ ��ȯ
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� Ŭ��
        {
            SceneManager.LoadScene("Loading"); // "Loading" �� �̸��� ���� �°� ����
        }
    }
}
