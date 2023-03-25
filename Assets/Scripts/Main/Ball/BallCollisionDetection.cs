using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionDetection : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private float bootImpulseForce = 20.75f;
    private float borderImpulseForce = 3.8f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 forceDirection = collision.contacts[0].normal;

        if(collision.gameObject.CompareTag("Player"))
        {         
            if(forceDirection.x == 0)
            {
                Vector2 extraImpulseForce = new Vector2(forceDirection.x * bootImpulseForce + 5, forceDirection.y * bootImpulseForce);
                rb.AddForce(extraImpulseForce, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(forceDirection * bootImpulseForce, ForceMode2D.Impulse);
            }
        }

        if(collision.gameObject.CompareTag("Border"))
        {
            rb.AddForce(forceDirection * borderImpulseForce, ForceMode2D.Impulse);
        }
    } 
}