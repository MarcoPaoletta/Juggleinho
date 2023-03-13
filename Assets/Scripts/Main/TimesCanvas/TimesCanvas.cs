using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimesCanvas : MonoBehaviour
{
    [SerializeField] private Text currentTimeText;
    [SerializeField] private Text bestTimeText;

    private float currentTimeInSeconds;

    private void Start()
    {
        UpdateCurrentTimeText();
        InvokeRepeating("IncreaseCurrentTime", 1f, 1f);
    }

    private void IncreaseCurrentTime()
    {
        currentTimeInSeconds += 1;
        UpdateCurrentTimeText();
    }

    private void UpdateCurrentTimeText()
    {
        int minutes = Mathf.FloorToInt(currentTimeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(currentTimeInSeconds % 60f);
        currentTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}