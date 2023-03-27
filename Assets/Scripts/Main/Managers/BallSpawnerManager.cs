using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> balls;
    [SerializeField] private CurrentTimeSetter currentTimeSetterScript;

    private int instantiatedBallsAmount;
    private int maxBallsAmount = 5;
    private bool maxBallsAmountReached;

    private void Start()
    {
        SpawnBall();
    }

    public void CheckBallSpawning()
    {
        if(currentTimeSetterScript.currentTimeInSeconds == 5 || currentTimeSetterScript.currentTimeInSeconds % 10 == 0 && currentTimeSetterScript.currentTimeInSeconds != 0 && instantiatedBallsAmount < maxBallsAmount)
        {
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        instantiatedBallsAmount += 1;
        Instantiate(balls[instantiatedBallsAmount - 1], Vector3.zero, Quaternion.identity);
    }
}