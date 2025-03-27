using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorningPortalBehavior : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = GameManager.instance;
        
        if(gameManager.IsStateCompleted(GameManager.State.completedNavigation) == true)
        {
            gameObject.SetActive(false);
            gameManager.ProgressState();
        }
    }
}
