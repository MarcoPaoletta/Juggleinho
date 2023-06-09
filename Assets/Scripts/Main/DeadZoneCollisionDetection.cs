using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZoneCollisionDetection : MonoBehaviour
{
    [SerializeField] private BestTimeSetter bestTimeSetterScript; 

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            bestTimeSetterScript.CheckBestTime();
            SceneManager.LoadScene("Lobby");
        }      
    }
}