using UnityEngine;

public class CardHoverEffect : MonoBehaviour
{
    public float hoverScale = 1.2f; // 마우스 오버 시 카드의 확대 배율
    private Vector3 originalScale; // 카드의 원래 크기
    private bool isHovered = false; // 카드가 마우스 위에 있는지 여부

    void Start()
    {
        // 카드의 원래 크기 저장
        originalScale = transform.localScale;
    }

    void Update()
    {
        // 마우스가 카드 위에 있는지 확인
        if (isHovered)
        {
            // 카드 크기를 확대
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale * hoverScale, Time.deltaTime * 10f);
        }
        else
        {
            // 카드 크기를 원래대로 돌아가게 함
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * 10f);
        }
    }

    void OnMouseEnter()
    {
        // 마우스가 카드 위에 있을 때
        isHovered = true;
    }

    void OnMouseExit()
    {
        // 마우스가 카드에서 벗어났을 때
        isHovered = false;
    }
}
