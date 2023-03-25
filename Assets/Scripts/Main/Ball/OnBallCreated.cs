using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBallCreated : MonoBehaviour
{
    [SerializeField] private BallRotation ballRotationScript;
    [SerializeField] private Rigidbody2D rb;

    private float impulseForce = 20;

    private void Start()
    {
        SetPosition();
        ApplyImpulse();
        ballRotationScript.AddRotation();
        Invoke("EnableDeadZone", 1.5f);
    }

    private void SetPosition()
    {
        float ballPositionX = Random.Range(-1.35f, -1.35f);
        float ballPositionY = -5.5f;
        Vector3 ballPosition = new Vector3(ballPositionX, ballPositionY, 0);
        transform.position = ballPosition;
    }

    private void ApplyImpulse()
    {
        float impulseX = Random.Range(-.2f, .2f);
        float impulseY = Random.Range(1f, 1.2f);
        Vector2 impulseDirection = new Vector2(impulseX, impulseY);
        rb.AddForce(impulseDirection * impulseForce, ForceMode2D.Impulse);
    }

    private void EnableDeadZone()
    {
        gameObject.layer = 8;
    }
}