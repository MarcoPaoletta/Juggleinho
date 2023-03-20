using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private float moveInput;
    private float speed = 6f;
    private float minPositionX = -2.25f;
    private float maxPositionX = 2.25f;

    private void Update()
    {
        Move();
        ClampPosition();
    }

    private void Move()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            Vector3 playerPosition = transform.position;
            playerPosition.x = touchPosition.x;
            transform.position = playerPosition;
        }
    }

    private void ClampPosition()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPositionX, maxPositionX), transform.position.y, transform.position.z);
    }
}