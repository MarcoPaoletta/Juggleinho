using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private float speed = 10f;
    private float minPositionX = -2.25f;
    private float maxPositionX = 2.25f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
    }
}