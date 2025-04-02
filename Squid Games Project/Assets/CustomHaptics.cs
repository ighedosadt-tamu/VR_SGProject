using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Input;

public class CustomHaptics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void happyPath(){
        Debug.Log("Triggered!");
        GetComponent<XRDirectInteractor>().SendHapticImpulse(0.5f, 1.0f);
    }

    public void sadPath1(){
        GetComponent<XRDirectInteractor>().SendHapticImpulse(0.2f, 2.0f);
    }

    public void sadPath2(){
        GetComponent<XRDirectInteractor>().SendHapticImpulse(0.5f, 0.5f);
    }

    public void sadPath3(){
        GetComponent<XRDirectInteractor>().SendHapticImpulse(1f, 1f);
    }
}
