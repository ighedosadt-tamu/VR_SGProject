using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLobbyPortalDay : MonoBehaviour
{
    public string currentRoomPortalName = "Day Portal";
    public GameObject interactionGM;

    private GameManager gameManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            gameManager = GameManager.instance;
            if (interactionGM.GetComponent<InteractionGM>().completedLevel == true)
            {
                gameManager.SetState(GameManager.State.completedNavigation, true);
                
            }
            gameManager.LoadScene(0); // Load lobby scene
            
        }
    }
}
