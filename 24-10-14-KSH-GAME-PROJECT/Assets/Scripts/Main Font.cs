using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainFont : MonoBehaviour
{
    float time;
    Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        // ���� ������Ʈ���� Text ������Ʈ ����
        textComponent = GetComponent<Text>();
    }
   
    // Update is called once per frame
    void Update()
    {
        if (textComponent != null)  // Text ������Ʈ�� �ִ��� Ȯ��
        {
            if (time < 0.5f)
            {
                // �ؽ�Ʈ ������ ���İ�(����) ����
                textComponent.color = new Color(1, 1, 1, 1 - time);
            }
            else
            {
                textComponent.color = new Color(1, 1, 1, time);
                if (time > 1f)
                {
                    time = 0;
                }
            }

            time += Time.deltaTime;
        }
    }
}
