using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordersPositioning : MonoBehaviour
{
    [SerializeField] private GameObject field;

    [Header("Borders")]
    [SerializeField] private GameObject leftBorder;
    [SerializeField] private GameObject rightBorder;

    private void Start()
    {
        SetLeftBorderPosition();
        SetRightBorderPosition();
    }

    private void SetLeftBorderPosition()
    {
        Vector3 leftBorderPosition = leftBorder.transform.position;
        leftBorderPosition.x = field.transform.localScale.x / -2 - leftBorder.transform.localScale.x / 2;
        leftBorder.transform.position = leftBorderPosition;
    }

    private void SetRightBorderPosition()
    {

    }
}