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
        friendlyNPCController.StartInteraction(true);
    }

    void OnTriggerExit(Collider other)
    {
        friendlyNPCController.StartInteraction(false);
    }
}
