using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireRay : MonoBehaviour
{
    public float maxDistance = 100f; // How far the ray should travel if it doesn't hit anything
    public LineRenderer lineRenderer;
    public Transform reflectionPoint;
    
    private ReflectRay prevHitReflectiveObject;

    // Start is called before the first frame update
    void Start()
    {
        
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        
        
        Vector3 origin = reflectionPoint.position;
        Vector3 direction = reflectionPoint.forward;
        RaycastHit hit;
        if (Physics.Raycast(origin, direction, out hit, maxDistance))
        {
            GameObject hitObject = hit.collider.gameObject;

            lineRenderer.SetPosition(0, origin);
            lineRenderer.SetPosition(1, hit.point);
            if (hitObject.tag == "Reflective Object")
            {
                
                ReflectRay reflectRay = hitObject.GetComponent<ReflectRay>();
                if (reflectRay != null)
                {
                    reflectRay.OnRayHit();
                    prevHitReflectiveObject = reflectRay;
                }


            }

            else 
            {

                if (prevHitReflectiveObject != null)
                {
                    if (prevHitReflectiveObject.hasFired)
                    {
                        prevHitReflectiveObject.StopRayHit();
                    }
                    prevHitReflectiveObject.stoppedBeingHit = true;
                }
            }
            
        }
        else
        {
            // If nothing is hit, draw the line out to the specified maxDistance
            lineRenderer.SetPosition(0, origin);
            lineRenderer.SetPosition(1, origin + direction * maxDistance);
            if (prevHitReflectiveObject != null)
            {
                if (prevHitReflectiveObject.hasFired)
                {
                    prevHitReflectiveObject.StopRayHit();
                }
                prevHitReflectiveObject.stoppedBeingHit = true;
            }
        }
        
        
    }


}
