using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemPickup : MonoBehaviour
{
    public int totalItems = 4;  // Total number of items in the scene
    private int itemsCollected = 0; // Number of items collected

    public GameManager gameManager;
    public void IncrementItemsCollected()
    {
        itemsCollected++;
        if (itemsCollected == totalItems)
        {
            Debug.Log("All items collected!");
            gameManager.CheckItemPickupTimeLimit();
        }
    }

    public float GetItemsCollected()
    {
        return itemsCollected;
    }
}
