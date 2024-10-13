using UnityEngine;

public class CardDrag : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private bool isOnLine = false;
    private Vector3 originalPosition;
    private CardPositionFixed cardPositionFixed;
    private BackgroundLinesGenerator linesGenerator;
    private Camera mainCamera;

    private void Awake()
    {
        cardPositionFixed = GetComponent<CardPositionFixed>();
        linesGenerator = FindObjectOfType<BackgroundLinesGenerator>();
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found!");
        }
    }

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void SetFixedPosition(Vector3 position)
    {
        if (cardPositionFixed != null)
        {
            cardPositionFixed.SetFixedPosition(position);
        }
    }

    private void Update()
    {
        if (mainCamera == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                offset = transform.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        if (isDragging)
        {
            Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            if (!isOnLine)
            {
                if (cardPositionFixed != null)
                {
                    cardPositionFixed.RestorePosition();
                }
                else
                {
                    transform.position = originalPosition;
                }
            }
            else
            {
                SnapToNearestLine();
            }
        }
    }

    private void SnapToNearestLine()
    {
        if (linesGenerator != null)
        {
            Vector2 nearestPosition = linesGenerator.GetNearestLinePosition(transform.position);
            transform.position = new Vector3(nearestPosition.x, nearestPosition.y, transform.position.z);
            SetFixedPosition(transform.position);

            (int x, int y) = linesGenerator.GetNearestLineIndex(transform.position);
            Debug.Log($"카드가 ({x},{y}) 배열에 놓였습니다.");
        }
        else
        {
            Debug.LogWarning("BackgroundLinesGenerator not found!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            isOnLine = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            isOnLine = false;
        }
    }
}