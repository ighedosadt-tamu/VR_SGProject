using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLobbyPortal : MonoBehaviour
{
    
    public string currentRoomPortalName = "Morning Portal";
    public GameObject navigationGM;

    private GameManager gameManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            gameManager = GameManager.instance;
            if (navigationGM.GetComponent<NavigationGM>().completedLevel == true)
            {
                gameManager.SetState(GameManager.State.completedNavigation, true);
                
            }
            gameManager.LoadScene(0); // Load lobby scene
            
        }
    }
}
