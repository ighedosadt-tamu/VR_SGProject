using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ColorShifting : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector4 color;

    // Update is called once per frame
    void Update()
    {
        var mat = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
        color.x = (float) Math.Abs(Math.Sin(Time.deltaTime));
        color.y = (float) Math.Abs(Math.Sin(Time.deltaTime + Math.PI/4.0f));
        color.z = (float) Math.Abs(Math.Sin(Time.deltaTime + Math.PI/2.0f));
        color[3] = 70.0f/255.0f;

        mat.color = color;
    }
}
