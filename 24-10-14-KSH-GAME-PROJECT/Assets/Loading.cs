using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;  // TextMeshPro ���ӽ����̽� �߰�

public class Loading : MonoBehaviour
{
    public Slider progressbar;
    public TextMeshProUGUI loadtext;  // TextMeshProUGUI�� ����

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Play");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;

            // Progressbar ���� 1�� �� ������ ����
            if (progressbar.value < 1f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }
            else
            {
                loadtext.text = "Press Screen";  // �ε��� �Ϸ�Ǹ� �ؽ�Ʈ ����
            }

            // SpaceŰ �Ǵ� ���콺 Ŭ������ �� ��ȯ
            if (progressbar != null && operation != null)
            {
                // Space Ű �Ǵ� ���콺 ���� Ŭ�� �� �� ��ȯ
                if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                    && progressbar.value >= 1f && operation.progress >= 0.9f)
                {
                    operation.allowSceneActivation = true;
                }
            }
            else
            {
                Debug.LogError("Progress bar or operation is not initialized properly.");
            }
        }
    }
}
