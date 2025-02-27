using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Item : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public float desroyDelay = 0.3f;
    public ItemPickup itemPickup;
    public GameManager gameManager;
    public ContinuousMoveProviderBase mp;
    public ContinuousTurnProviderBase tp;
    public void speedUp(){
        mp.moveSpeed += 3;
        tp.turnSpeed += 30;
    }

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
            if(this.gameObject.tag == "Coffee"){
                itemPickup.CoffeeGrabbed();
                speedUp();
            }
                

           gameObject.SetActive(false);
        }
        
    }
}
