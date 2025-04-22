using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyNPCInteractZoneController : MonoBehaviour
{
    FriendlyNPCController friendlyNPCController;
    void Start()
    {
        friendlyNPCController = GetComponentInParent<FriendlyNPCController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            friendlyNPCController.StartInteraction(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            friendlyNPCController.StartInteraction(false);
    }
}
