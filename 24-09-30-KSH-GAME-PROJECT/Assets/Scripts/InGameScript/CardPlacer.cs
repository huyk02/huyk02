using UnityEngine;

public class CardPlacer : MonoBehaviour
{
    public BackgroundLinesGenerator linesGenerator;
    public GameObject[] cardPrefabs;
    public float cardYOffset = -0.5f; // 카드를 라인 아래에 약간 오프셋하여 배치

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

        // 카드 배치 로그 출력
        Debug.Log($"카드가 ({x},{y}) 배열에 놓였습니다.");

        // 카드의 위치를 고정하고 드래그 기능 추가 (선택적)
        CardPositionFixed cardPositionFixed = card.AddComponent<CardPositionFixed>();
        cardPositionFixed.SetFixedPosition(position);

        CardDrag cardDrag = card.AddComponent<CardDrag>();
        cardDrag.SetFixedPosition(position);
    }
}