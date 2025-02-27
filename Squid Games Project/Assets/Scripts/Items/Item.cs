using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Item : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public float desroyDelay = 1f;
    public ItemPickup itemPickup;
    public GameManager gameManager;


    void Awake()
    {
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (!gameManager.RanOutOfTime())
        {
            itemPickup.IncrementItemsCollected();
            Debug.Log("Item collected!");

            // Disable interactions to prevent further grabbing
            //grabInteractable.enabled = false;

            Destroy(gameObject, desroyDelay);
        }
        
    }
}
