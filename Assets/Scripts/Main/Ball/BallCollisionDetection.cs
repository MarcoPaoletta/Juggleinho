using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionDetection : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private float bootImpulseForce = 18f;
    private float bootXMultiplier;

    private float borderImpulseForce = 2.75f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 forceDirection = collision.contacts[0].normal;

        if(collision.gameObject.CompareTag("Player"))
        {
            if(forceDirection.x == 0)
            {
                int random = Random.Range(1, 3);

                if(random == 1)
                {
                    bootXMultiplier = Random.Range(0.7f, 1f);
                }

                if(random == 2)
                {
                    bootXMultiplier = Random.Range(-1f, -0.7f);
                }

                Vector2 forceToApply = new Vector2(forceDirection.x * bootXMultiplier * bootImpulseForce, forceDirection.y * bootImpulseForce);
                rb.AddForce(forceToApply, ForceMode2D.Impulse);
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