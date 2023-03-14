using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private CurrentTimeSetter currentTimeSetterScript;

    private void Start()
    {
        SpawnBall();
    }

    private void SpawnBall()
    {
        Instantiate(ball, Vector3.zero, Quaternion.identity);
    }

    public void CheckBallSpawning()
    {
        if(currentTimeSetterScript.currentTimeInSeconds % 10 == 0 && currentTimeSetterScript.currentTimeInSeconds != 0)
        {
            SpawnBall();
        }
    }
}