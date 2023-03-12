using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootActivationManager : MonoBehaviour
{
    [SerializeField] private GameObject boot;

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            worldPos.z = 10;
            boot.SetActive(true);
            boot.transform.position = worldPos;
        }
        else
        {
            boot.SetActive(false);
        }
    }
}