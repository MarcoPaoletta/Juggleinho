using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootCollisionDetection : MonoBehaviour
{
    private float impulseForce = 8.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D collidingRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 direction = collision.contacts[0].point - (Vector2)transform.position;
            direction = direction.normalized;
            collidingRb.AddForce(direction * impulseForce, ForceMode2D.Impulse);
        }
    }   
}