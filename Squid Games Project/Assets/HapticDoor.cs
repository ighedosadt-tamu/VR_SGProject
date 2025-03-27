using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticDoor : MonoBehaviour
{
    public HapticGM gameManager;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        if(other.tag == "Player") {
            gameManager.completedLevel = true;
            gameManager.CheckItemPickupTimeLimit();
        }
           
    }
}
