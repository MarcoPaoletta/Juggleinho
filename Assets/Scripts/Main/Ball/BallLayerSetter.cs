using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLayerSetter : MonoBehaviour
{
    private int ballLayerIndex = 7;
    private int ignoreObjectsLayerIndex = 3;

    private void Start()
    {
        Invoke("ChangeToBallLayer", 1f);
    }

    public void ChangeToBallLayer()
    {
        gameObject.layer = ballLayerIndex;
    }

    public void StartBootCollisionCooldown()
    {
        gameObject.layer = ignoreObjectsLayerIndex;
        Invoke("ChangeToBallLayer", .5f);
    }
}