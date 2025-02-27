using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemPickup : MonoBehaviour
{
    public int totalItems = 4;  // Total number of items in the scene
    private int itemsCollected = 0; // Number of items collected
    public TMPro.TextMeshProUGUI resultText;

    public GameManager gameManager;
    public void IncrementItemsCollected()
    {
        itemsCollected++;
        
        if (itemsCollected == totalItems)
        {
            Debug.Log("All items collected!");
            gameManager.CheckItemPickupTimeLimit();
        }
        else
        {
            resultText.text = "Look around and grab morning objects!\n\n" + itemsCollected + "/4\nMorning Objects\nGathered.";
        }
    }

    public void CoffeeGrabbed(){
        resultText.text = "Look around and grab morning objects!\n\n" + itemsCollected + "/4\nMorning Objects\nGathered.\n" + "You feel energized!";
    }

    public float GetItemsCollected()
    {
        return itemsCollected;
    }
}
