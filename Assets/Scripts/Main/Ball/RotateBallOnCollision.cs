using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBallOnCollision : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private float rotationSpeed = 20f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Boot") || other.gameObject.CompareTag("Border"))
        {
            float torque = rb.velocity.magnitude / rotationSpeed;
            print(torque);
            rb.AddTorque(torque);
        }
    }
}