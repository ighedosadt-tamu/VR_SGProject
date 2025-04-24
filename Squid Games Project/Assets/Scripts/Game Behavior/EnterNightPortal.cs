using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterNightPortal : MonoBehaviour
{
    public string currentRoomPortalName = "Night Portal";
    public GameObject hapticGM;

    private GameManager gameManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            gameManager = GameManager.instance;
            if (hapticGM.GetComponent<HapticGM>().completedLevel == true)
            {
                gameManager.SetState(GameManager.State.completedHaptics, true);
                
            }
            gameManager.LoadScene(0); // Load lobby scene
            
        }
    }
}
