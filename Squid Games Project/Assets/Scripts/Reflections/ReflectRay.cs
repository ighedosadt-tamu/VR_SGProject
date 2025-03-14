using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectRay : MonoBehaviour
{
    public float maxDistance = 100f; // How far the ray should travel if it doesn't hit anything
    public LineRenderer lineRenderer;
    public Transform reflectionPoint;


    public bool stoppedBeingHit = false;
    public bool hasFired = false;
    private ReflectRay prevHitReflectiveObject;
    // Start is called before the first frame update
    void Start()
    {
        
        lineRenderer.enabled = false;
    }
    void Update()
    {
        if (stoppedBeingHit)
        {
            StopRayHit();
        }
    }

    public void OnRayHit()
    {
        lineRenderer.positionCount = 2;
        hasFired = true;
        lineRenderer.enabled = true;
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

    public void StopRayHit()
    {
        lineRenderer.positionCount = 0;
        lineRenderer.enabled = false;
        hasFired = false;
        stoppedBeingHit = false;
        if (prevHitReflectiveObject)
        {
            prevHitReflectiveObject.StopRayHit();
        }

    }
}
