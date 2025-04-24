using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTwilightPortal : MonoBehaviour
{
    public string currentRoomPortalName = "Twilight Portal";
    public GameObject passthroughGM;

    private GameManager gameManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            gameManager = GameManager.instance;
            if (passthroughGM.GetComponent<PassthroughManager>().completedLevel == true)
            {
                gameManager.SetState(GameManager.State.completedPassthrough, true);
                
            }
            gameManager.LoadScene(0); // Load lobby scene
            
        }
    }
}
