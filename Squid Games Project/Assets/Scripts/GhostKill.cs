using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GhostKill : MonoBehaviour
{
    public int totalItems = 5;  // Total number of items in the scene
    private int itemsCollected = 0; // Number of items collected
    public TMPro.TextMeshProUGUI resultText;

    public PassthroughManager ptGM;
    public void IncrementGhost()
    {
        itemsCollected++;
        
        if (itemsCollected == totalItems && ptGM.timeRemaining > 0)
        {
            ptGM.CheckItemPickupTimeLimit();
        }
        else if (ptGM.timeRemaining > 0)
        {
            resultText.text = "Stare the ghosts down!\n\n" + itemsCollected + "/5\nGhosts Defeated.";
        }
    }

    public float GetGhostCollected()
    {
        return itemsCollected;
    }
}
