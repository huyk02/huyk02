using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;  // TextMeshPro 네임스페이스 추가

public class Loading : MonoBehaviour
{
    public Slider progressbar;
    public TextMeshProUGUI loadtext;  // TextMeshProUGUI로 변경

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

            // Progressbar 값이 1이 될 때까지 증가
            if (progressbar.value < 1f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }
            else
            {
                loadtext.text = "Press Screen";  // 로딩이 완료되면 텍스트 변경
            }

            // Space키 또는 마우스 클릭으로 씬 전환
            if (progressbar != null && operation != null)
            {
                // Space 키 또는 마우스 왼쪽 클릭 시 씬 전환
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
