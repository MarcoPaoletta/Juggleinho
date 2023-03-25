using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeSetter : MonoBehaviour
{
    [HideInInspector] public int bestTime;

    [SerializeField] private Text bestTimeText;
    [SerializeField] private CurrentTimeSetter currentTimeSetterScript;

    private void Start()
    {
        LoadData();
        CheckBestTime();
        SetBestTimeText();
    }

    private void LoadData()
    {
        BestTimeData bestTimeData = SaveAndLoadManager.LoadBestTimeData();
        bestTime = bestTimeData.bestTime;
    }

    public void CheckBestTime()
    {
        if(currentTimeSetterScript.currentTimeInSeconds > bestTime)
        {
            bestTime = currentTimeSetterScript.currentTimeInSeconds;
        }

        SaveAndLoadManager.SaveBestTimeData(this);
    }

    private void SetBestTimeText()
    {
        int minutes = Mathf.FloorToInt(bestTime / 60f);
        int seconds = Mathf.FloorToInt(bestTime % 60f);
        bestTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}