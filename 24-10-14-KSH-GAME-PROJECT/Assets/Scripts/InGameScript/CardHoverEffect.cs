using UnityEngine;

public class CardHoverEffect : MonoBehaviour
{
    public float hoverScale = 1.2f; // ���콺 ���� �� ī���� Ȯ�� ����
    private Vector3 originalScale; // ī���� ���� ũ��
    private bool isHovered = false; // ī�尡 ���콺 ���� �ִ��� ����

    void Start()
    {
        // ī���� ���� ũ�� ����
        originalScale = transform.localScale;
    }

    void Update()
    {
        // ���콺�� ī�� ���� �ִ��� Ȯ��
        if (isHovered)
        {
            // ī�� ũ�⸦ Ȯ��
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale * hoverScale, Time.deltaTime * 10f);
        }
        else
        {
            // ī�� ũ�⸦ ������� ���ư��� ��
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * 10f);
        }
    }

    void OnMouseEnter()
    {
        // ���콺�� ī�� ���� ���� ��
        isHovered = true;
    }

    void OnMouseExit()
    {
        // ���콺�� ī�忡�� ����� ��
        isHovered = false;
    }
}
