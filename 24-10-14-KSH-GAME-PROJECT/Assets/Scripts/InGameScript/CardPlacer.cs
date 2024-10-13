using UnityEngine;

public class CardPlacer : MonoBehaviour
{
    public BackgroundLinesGenerator linesGenerator;
    public GameObject[] cardPrefabs;
    public float cardYOffset = -0.5f; // ī�带 ���� �Ʒ��� �ణ �������Ͽ� ��ġ

    void Start()
    {
        if (linesGenerator == null)
        {
            Debug.LogError("LinesGenerator is not assigned.");
            return;
        }

        if (cardPrefabs.Length == 0)
        {
            Debug.LogError("No card prefabs assigned.");
            return;
        }

        PlaceCardsOnLines();
    }

    void PlaceCardsOnLines()
    {
        for (int x = 0; x < linesGenerator.horizontalLines; x++)
        {
            for (int y = 0; y < linesGenerator.verticalLines; y++)
            {
                Vector2 linePosition = linesGenerator.GetLinePosition(x, y);
                Vector3 cardPosition = new Vector3(linePosition.x, linePosition.y + cardYOffset, 0);
                PlaceCardAtPosition(cardPosition, x, y);
            }
        }
    }

    void PlaceCardAtPosition(Vector3 position, int x, int y)
    {
        GameObject selectedCardPrefab = cardPrefabs[Random.Range(0, cardPrefabs.Length)];
        GameObject card = Instantiate(selectedCardPrefab, position, Quaternion.identity);
        card.transform.SetParent(transform);

        // ī�� ��ġ �α� ���
        Debug.Log($"ī�尡 ({x},{y}) �迭�� �������ϴ�.");

        // ī���� ��ġ�� �����ϰ� �巡�� ��� �߰� (������)
        CardPositionFixed cardPositionFixed = card.AddComponent<CardPositionFixed>();
        cardPositionFixed.SetFixedPosition(position);

        CardDrag cardDrag = card.AddComponent<CardDrag>();
        cardDrag.SetFixedPosition(position);
    }
}