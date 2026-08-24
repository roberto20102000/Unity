using UnityEngine;

public class CellTouchController : MonoBehaviour
{
    public float rotationSpeed = 0.2f;
    public float zoomSpeed = 0.001f;

    private float previousDistance;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            float currentDistance =
                Vector2.Distance(
                    touch0.position,
                    touch1.position
                );

            if (previousDistance != 0)
            {
                float difference =
                    currentDistance - previousDistance;

                Vector3 newScale =
                    transform.localScale +
                    Vector3.one *
                    difference *
                    zoomSpeed;

                newScale.x =
                    Mathf.Clamp(newScale.x, 0.1f, 5f);

                newScale.y =
                    Mathf.Clamp(newScale.y, 0.1f, 5f);

                newScale.z =
                    Mathf.Clamp(newScale.z, 0.1f, 5f);

                transform.localScale = newScale;
            }

            previousDistance = currentDistance;

            Vector2 previousDirection =
                touch0.position -
                touch1.position;

            Vector2 currentDirection =
                (touch0.position - touch0.deltaPosition) -
                (touch1.position - touch1.deltaPosition);

            float rotation =
                Vector2.SignedAngle(
                    currentDirection,
                    previousDirection
                );

            transform.Rotate(
                Vector3.up,
                rotation * rotationSpeed,
                Space.World
            );
        }
        else
        {
            previousDistance = 0;
        }
    }
}