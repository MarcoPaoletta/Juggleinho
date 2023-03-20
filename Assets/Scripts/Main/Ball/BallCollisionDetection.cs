using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionDetection : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private float bootImpulseForce = 18f;
    private float borderImpulseForce = 2.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 forceDirection = collision.contacts[0].normal;

        if(collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce(forceDirection * bootImpulseForce, ForceMode2D.Impulse);
        }

        if(collision.gameObject.CompareTag("Border"))
        {
            rb.AddForce(forceDirection * borderImpulseForce, ForceMode2D.Impulse);
        }
    } 
}