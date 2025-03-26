using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class DisabledCube : MonoBehaviour
{
    [SerializeField]
    public GameObject MirrorCube;
    public GameObject darkCube;
    public Material lookedD;
    public Material defaultD;

    public void onLook(){
        darkCube.GetComponent<MeshRenderer>().material = lookedD;
    }
    public void offLook(){
        darkCube.GetComponent<MeshRenderer>().material = defaultD;
    }

    public void onStare(){
        Debug.Log("Cube stared at!");
        MirrorCube.SetActive(true);
        darkCube.SetActive(false);
    }
}
