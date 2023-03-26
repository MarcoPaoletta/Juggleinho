using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitToField : MonoBehaviour
{
    public SpriteRenderer fieldSpriteRenderer;

	private void Start () 
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = fieldSpriteRenderer.bounds.size.x / fieldSpriteRenderer.bounds.size.y;

        if(screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = fieldSpriteRenderer.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = fieldSpriteRenderer.bounds.size.y / 2 * differenceInSize;
        }
	}
}