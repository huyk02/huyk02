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
        // 게임 오브젝트에서 Text 컴포넌트 참조
        textComponent = GetComponent<Text>();
    }
   
    // Update is called once per frame
    void Update()
    {
        if (textComponent != null)  // Text 컴포넌트가 있는지 확인
        {
            if (time < 0.5f)
            {
                // 텍스트 색상의 알파값(투명도) 변경
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
