using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RayInteraction : MonoBehaviour
{
    [Header("XR Input Actions")]
    [Description("Grab button to select an object")]
    public InputActionProperty selectButton;
    [Header("Locomotion Providers to Disable")]
    public ContinuousMoveProviderBase cmp;
    public ContinuousTurnProviderBase ctp;
    [Header("Line Render Settings")]
    public Transform controllerOrigin;
    public float maxDistance = 10f;
    public LineRenderer lineRenderer;
    
    private bool hasSelectedObject = false;
    private ObjectTransformation selectedObject = null;

    // Update is called once per frame
    void Start()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = true;
    }
    void Update()
    {
        RaycastHit hit;
        bool didHit = Physics.Raycast(controllerOrigin.position, controllerOrigin.forward, out hit, maxDistance);
        if (didHit)
        {
            lineRenderer.SetPosition(0, controllerOrigin.position);
            lineRenderer.SetPosition(1, hit.point);
            lineRenderer.startColor = Color.red;
        }
        else
        {
            lineRenderer.SetPosition(0, controllerOrigin.position);
            lineRenderer.SetPosition(1, controllerOrigin.position + controllerOrigin.forward * maxDistance);
            lineRenderer.startColor = Color.green;
        }

        if (selectButton.action.WasPressedThisFrame())
        {
            if (!hasSelectedObject)
            {
                // We don't have anything selected yet, so let's see if we hit a "Reflective Object"
                if (didHit && hit.collider.CompareTag("Reflective Object"))
                {
                    // Select it
                    hasSelectedObject = true;
                    ToggleLocomotion(false);
                    selectedObject = hit.collider.GetComponent<ObjectTransformation>();
                }
            }
            else
            {
                // Deselect it
                hasSelectedObject = false;
                ToggleLocomotion(true);
                selectedObject = null;

            }
        }

        if(hasSelectedObject && selectedObject != null)
        {
            selectedObject.TransformObject();
        }

        

    }

    private void ToggleLocomotion(bool toggle)
    {
        if(!toggle){
            ctp.turnSpeed = 0;
            cmp.moveSpeed = 0;
        }
        else{
            ctp.turnSpeed = 60;
            cmp.moveSpeed = 3;
        }
        
    }
}
