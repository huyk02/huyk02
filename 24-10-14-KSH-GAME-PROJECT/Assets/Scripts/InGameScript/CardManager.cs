using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject[] cardPrefabs; // 카드 프리팹 배열
    public int numberOfCards = 5; // 생성할 카드 개수
    public Transform centerPoint; // 카드 배열의 중앙점으로 사용될 Transform

    private float cardSpacing; // 카드 간격을 동적으로 설정

    void Start()
    {
        AdjustCardSpacingBasedOnCamera();
        SpawnRandomCardsInHorizontalRow();
    }

    // iOS 메인 카메라를 기준으로 카드 간격을 조정하는 함수
    void AdjustCardSpacingBasedOnCamera()
    {
        // 카메라의 세로 크기(orthographicSize)를 이용해 화면의 세로 길이를 계산
        float screenHeight = Camera.main.orthographicSize * 2;
        // 화면의 비율(aspect)를 이용해 가로 길이를 계산
        float screenWidth = screenHeight * Camera.main.aspect;

        // 화면 너비의 일정 비율로 카드 간격을 설정 (예: 전체 화면 너비의 10%)
        cardSpacing = screenWidth * 0.1f; // 카드 간격을 화면 너비의 10%로 설정
    }

    // 카드를 가로로 배치하는 함수
    void SpawnRandomCardsInHorizontalRow()
    {
        if (cardPrefabs.Length > 0 && numberOfCards > 0)
        {
            // y축의 고정 위치
            float fixedY = centerPoint.position.y;

            // 전체 카드 배열의 너비 (카드 간격 포함)
            float totalWidth = (numberOfCards - 1) * cardSpacing;

            // 배열의 시작 위치를 가운데에서 좌우로 분산
            float startX = centerPoint.position.x - totalWidth / 2;

            for (int i = 0; i < numberOfCards; i++)
            {
                // 각 카드의 x 위치를 계산
                float xPosition = startX + i * cardSpacing;

                // 랜덤한 카드 프리팹 선택
                GameObject selectedCardPrefab = cardPrefabs[Random.Range(0, cardPrefabs.Length)];

                // 배치할 카드의 위치 설정
                Vector3 spawnPosition = new Vector3(xPosition, fixedY, 0f);

                // 카드 생성
                GameObject card = Instantiate(selectedCardPrefab, spawnPosition, Quaternion.identity);

                // 카드의 z축을 약간 뒤로 배치하여 겹치지 않도록 설정 (시각적 깊이 효과)
                card.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, -i * 0.1f);

                // 카드 위치를 고정하고 드래그 기능을 추가 (선택적으로 추가)
                CardPositionFixed cardPositionFixed = card.AddComponent<CardPositionFixed>();
                cardPositionFixed.SetFixedPosition(spawnPosition);

                CardDrag cardDrag = card.AddComponent<CardDrag>();
                cardDrag.SetFixedPosition(spawnPosition); // 드래그 후 돌아올 위치 설정
            }
        }
        else
        {
            Debug.LogError("Card prefabs are missing or number of cards is invalid in CardManager.");
        }
    }
}
