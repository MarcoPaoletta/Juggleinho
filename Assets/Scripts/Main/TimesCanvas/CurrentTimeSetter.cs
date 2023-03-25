using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTimeSetter : MonoBehaviour
{
    [HideInInspector] public int currentTimeInSeconds;

    [SerializeField] private Text currentTimeText;
    [SerializeField] private BallSpawnerManager ballSpawnerManagerScript;

    private void Start()
    {
        UpdateCurrentTimeText();
        InvokeRepeating("IncreaseCurrentTime", 1f, 1f);
    }

    private void IncreaseCurrentTime()
    {
        currentTimeInSeconds += 1;
        UpdateCurrentTimeText();
        ballSpawnerManagerScript.CheckBallSpawning();
    }

    private void UpdateCurrentTimeText()
    {
        int minutes = Mathf.FloorToInt(currentTimeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(currentTimeInSeconds % 60f);
        currentTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}