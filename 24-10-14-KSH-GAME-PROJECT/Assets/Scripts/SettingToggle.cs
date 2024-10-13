using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingToggle : MonoBehaviour
{
    public Button optionButton;
    public GameObject settingPanel;
    public Camera mainCamera;

    private void Start()
    {
        // Option 버튼에 클릭 이벤트 추가
        optionButton.onClick.AddListener(ShowSettingPanel);

        // Setting 패널 초기 상태를 비활성화
        settingPanel.SetActive(false);
    }

    private void Update()
    {
        // Setting 패널이 활성화된 상태에서 마우스 클릭 감지
        if (settingPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            // 마우스 클릭 위치를 Ray로 변환
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Raycast를 통해 클릭한 오브젝트 감지
            if (Physics.Raycast(ray, out hit))
            {
                // 클릭한 오브젝트가 Setting 패널이 아니면 패널 숨기기
                if (hit.collider.gameObject != settingPanel)
                {
                    HideSettingPanel();
                }
            }
            else
            {
                // Raycast에 아무것도 감지되지 않으면 패널 숨기기
                HideSettingPanel();
            }
        }
    }

    private void ShowSettingPanel()
    {
        settingPanel.SetActive(true);
    }

    private void HideSettingPanel()
    {
        settingPanel.SetActive(false);
    }
}
