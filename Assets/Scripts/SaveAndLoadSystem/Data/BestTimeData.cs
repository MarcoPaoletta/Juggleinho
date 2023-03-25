using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BestTimeData
{   
    public int bestTime;

    public BestTimeData(BestTimeSetter bestTimeSetter)
    {
        bestTime = bestTimeSetter.bestTime;
    }
}