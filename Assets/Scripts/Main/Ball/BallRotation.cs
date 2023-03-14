using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private float rotationSpeed = 3f;

    public void AddRotation()
    {
        float torque = rb.velocity.magnitude / rotationSpeed;
        rb.AddTorque(torque);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Boot") || other.gameObject.CompareTag("Border"))
        {
            AddRotation();
        }
    }
}