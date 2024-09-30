using UnityEngine;

public class LineSpawner : MonoBehaviour
{
    public GameObject linePrefab; // 라인을 나타내는 프리팹
    public int numberOfLines = 4; // 생성할 라인의 수

    void Start()
    {
        SpawnLines();
    }

    void SpawnLines()
    {
        if (linePrefab == null)
        {
            Debug.LogError("Line prefab is not assigned.");
            return;
        }

        float screenHeight = Camera.main.orthographicSize * 2;
        float screenWidth = screenHeight * Camera.main.aspect;

        float lineSpacing = screenWidth / (numberOfLines + 1);

        for (int i = 0; i < numberOfLines; i++)
        {
            float positionX = -screenWidth / 2 + (i + 1) * lineSpacing;

            Vector3 startPoint = new Vector3(positionX, -screenHeight / 2, 0);
            Vector3 endPoint = new Vector3(positionX, screenHeight / 2, 0);

            GameObject lineObject = Instantiate(linePrefab, transform);
            LineObjectSetup(lineObject, startPoint, endPoint);
        }
    }

    void LineObjectSetup(GameObject lineObject, Vector3 startPoint, Vector3 endPoint)
    {
        // LineObject를 시작점과 끝점으로 설정
        lineObject.transform.position = (startPoint + endPoint) / 2;
        lineObject.transform.localScale = new Vector3(1, Vector3.Distance(startPoint, endPoint), 1);
        lineObject.transform.up = endPoint - startPoint;
    }
}
