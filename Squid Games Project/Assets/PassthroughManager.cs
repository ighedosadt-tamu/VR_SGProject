using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassthroughManager : MonoBehaviour
{
    public OVRPassthroughLayer layer1;
    public OVRPassthroughLayer layer2;
    private bool toggle = false;
    private bool op = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SwitchLayers()
    {
        if (!toggle)
        {
            toggle = true;
            layer1.enabled = false;
            layer2.enabled = true;
        }
        else
        {
            toggle = false;
            layer1.enabled = true;
            layer2.enabled = false;
        }
    }
    
    public void ChangeOpacity()
    {
        if (!op)
        {
            layer1.textureOpacity = 1;
            op = true;
        }
        else
        {
            layer1.textureOpacity = 0.2f;
            op = false;
        }
    }
}
