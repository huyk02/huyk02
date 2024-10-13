using UnityEngine;

public class CardPositionFixed : MonoBehaviour
{
    private Vector3 fixedPosition;

    public void SetFixedPosition(Vector3 position)
    {
        fixedPosition = position;
    }

    public void RestorePosition()
    {
        transform.position = fixedPosition;
    }
}
