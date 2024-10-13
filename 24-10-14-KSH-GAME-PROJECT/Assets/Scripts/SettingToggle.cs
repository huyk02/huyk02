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
        // Option ��ư�� Ŭ�� �̺�Ʈ �߰�
        optionButton.onClick.AddListener(ShowSettingPanel);

        // Setting �г� �ʱ� ���¸� ��Ȱ��ȭ
        settingPanel.SetActive(false);
    }

    private void Update()
    {
        // Setting �г��� Ȱ��ȭ�� ���¿��� ���콺 Ŭ�� ����
        if (settingPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            // ���콺 Ŭ�� ��ġ�� Ray�� ��ȯ
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Raycast�� ���� Ŭ���� ������Ʈ ����
            if (Physics.Raycast(ray, out hit))
            {
                // Ŭ���� ������Ʈ�� Setting �г��� �ƴϸ� �г� �����
                if (hit.collider.gameObject != settingPanel)
                {
                    HideSettingPanel();
                }
            }
            else
            {
                // Raycast�� �ƹ��͵� �������� ������ �г� �����
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
