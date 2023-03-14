using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    private void Start()
    {
        SpawnBall();
    }

    private void SpawnBall()
    {
        Instantiate(ball, Vector3.zero, Quaternion.identity);
    }
}