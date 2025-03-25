using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    private bool door_open = false;
    public GameObject doorPivot;

    private void OnTriggerEnter(Collider other) {
        string tag = other.gameObject.tag;

        if (tag == "Player" && !door_open)
        {
            door_open = true;
            doorPivot.GetComponent<Animation>().Play("DoorOpen");
            
        }
    }
    
}
