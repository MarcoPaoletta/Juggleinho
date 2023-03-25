using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRight : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [Header("Limits")]
    [SerializeField] private float minPositionX;
    [SerializeField] private float maxPositionX;

    private bool isMouseDown;

    private void Update()
    {
        Move();
        ClampPosition();
    }

    private void Move()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];

            if (touch.position.x >= Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    isMouseDown = true;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    isMouseDown = false;
                }

                if (isMouseDown)
                {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = 0f;
                    Vector3 playerPosition = transform.position;
                    playerPosition.x = touchPosition.x;
                    transform.position = playerPosition;
                }
            }
        }
    }

    private void ClampPosition()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPositionX, maxPositionX), transform.position.y, transform.position.z);
    }
}