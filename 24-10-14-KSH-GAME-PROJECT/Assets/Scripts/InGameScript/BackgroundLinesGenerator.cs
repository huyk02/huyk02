using UnityEngine;

public class BackgroundLinesGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    public int horizontalLines = 5;
    public int verticalLines = 4;
    public float lineWidth = 0.1f;
    public Color lineColor = Color.white;
    public float margin = 0.1f;

    private Vector2[,] linePositions;

    private void Start()
    {
        AdjustCameraForiOS();
        GenerateLines();
    }

    // iOS 디바이스에 맞춰 카메라 설정
    private void AdjustCameraForiOS()
    {
        // iOS 화면의 비율에 따라 카메라 설정 (16:9 기준)
        float targetAspect = 9.0f / 16.0f;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Camera camera = Camera.main;

        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            camera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = camera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            camera.rect = rect;
        }
    }

    private void GenerateLines()
    {
        float screenHeight = Camera.main.orthographicSize * 2;
        float screenWidth = screenHeight * Camera.main.aspect;

        float horizontalSpacing = screenWidth / (horizontalLines + 1);
        float verticalSpacing = screenHeight / (verticalLines + 1);

        linePositions = new Vector2[horizontalLines, verticalLines];

        for (int x = 0; x < horizontalLines; x++)
        {
            for (int y = 0; y < verticalLines; y++)
            {
                float xPos = -screenWidth / 2 + (x + 1) * horizontalSpacing;
                float yPos = -screenHeight / 2 + (y + 1) * verticalSpacing;

                Vector3 position = new Vector3(xPos, yPos, 0);
                GameObject lineObject = Instantiate(linePrefab, position, Quaternion.identity, transform);
                lineObject.name = $"Line_{x}_{y}";

                LineRenderer lineRenderer = lineObject.GetComponent<LineRenderer>();
                if (lineRenderer == null)
                {
                    lineRenderer = lineObject.AddComponent<LineRenderer>();
                }

                SetupLineRenderer(lineRenderer);

                linePositions[x, y] = new Vector2(xPos, yPos);

                AddLineNumberText(lineObject, $"({x},{y})");
            }
        }
    }

    private void SetupLineRenderer(LineRenderer lineRenderer)
    {
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = lineWidth;
        lineRenderer.positionCount = 2;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.sortingOrder = -1;
    }

    private void AddLineNumberText(GameObject lineObject, string text)
    {
        GameObject textObject = new GameObject("LineNumber");
        textObject.transform.SetParent(lineObject.transform);
        textObject.transform.localPosition = Vector3.zero;

        TextMesh textMesh = textObject.AddComponent<TextMesh>();
        textMesh.text = text;
        textMesh.fontSize = 28;
        textMesh.alignment = TextAlignment.Center;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.color = Color.black;

        textObject.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
    }

    public Vector2 GetLinePosition(int x, int y)
    {
        if (x < 0 || x >= horizontalLines || y < 0 || y >= verticalLines)
        {
            Debug.LogWarning("Invalid line index");
            return Vector2.zero;
        }
        return linePositions[x, y];
    }

    public Vector2 GetNearestLinePosition(Vector3 position)
    {
        float minDistance = float.MaxValue;
        Vector2 nearestPosition = Vector2.zero;

        for (int x = 0; x < horizontalLines; x++)
        {
            for (int y = 0; y < verticalLines; y++)
            {
                Vector2 linePosition = linePositions[x, y];
                float distance = Vector2.Distance(linePosition, position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestPosition = linePosition;
                }
            }
        }

        return nearestPosition;
    }

    public (int x, int y) GetNearestLineIndex(Vector3 position)
    {
        float minDistance = float.MaxValue;
        int nearestX = 0;
        int nearestY = 0;

        for (int x = 0; x < horizontalLines; x++)
        {
            for (int y = 0; y < verticalLines; y++)
            {
                Vector2 linePosition = linePositions[x, y];
                float distance = Vector2.Distance(linePosition, position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestX = x;
                    nearestY = y;
                }
            }
        }

        return (nearestX, nearestY);
    }
}
