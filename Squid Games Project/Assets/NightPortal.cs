using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightPortal : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        
        if(gameManager.IsStateCompleted(GameManager.State.completedHaptics) == true)
        {
            gameObject.SetActive(false);
            gameManager.ProgressState();
        }
    }
}
