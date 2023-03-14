using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBallCreated : MonoBehaviour
{
    [SerializeField] private BallRotation ballRotationScript;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CircleCollider2D circleCollider;

    private float impulseForce = 20;

    private void Start()
    {
        SetPosition();
        ApplyImpulse();
        ballRotationScript.AddRotation();
        Invoke("EnableCollider", 1f);
    }

    private void SetPosition()
    {
        float ballPositionX = Random.Range(-1.5f, 1.5f);
        float ballPositionY = -5.5f;
        Vector3 ballPosition = new Vector3(ballPositionX, ballPositionY, 0);
        transform.position = ballPosition;
    }

    private void ApplyImpulse()
    {
        rb.AddForce(new Vector2(.05f, 1) * impulseForce, ForceMode2D.Impulse);
    }

    private void EnableCollider()
    {
        circleCollider.enabled = true;
    }
}