using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private CurrentTimeSetter currentTimeSetterScript;

    private int ballsAmount;
    private int maxBallsAmount = 5;
    private bool maxBallsAmountReached;

    private void Start()
    {
        SpawnBall();
    }

    public void CheckBallSpawning()
    {
        if(currentTimeSetterScript.currentTimeInSeconds == 5 || currentTimeSetterScript.currentTimeInSeconds % 10 == 0 && currentTimeSetterScript.currentTimeInSeconds != 0 && ballsAmount < maxBallsAmount)
        {
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        ballsAmount += 1;
        Instantiate(ball, Vector3.zero, Quaternion.identity);
    }
}