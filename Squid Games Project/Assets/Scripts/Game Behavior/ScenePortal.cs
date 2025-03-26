using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePortal : MonoBehaviour
{
    public int sceneIndex = 1;
    GameManager gameManager;

    

    void OnTriggerEnter(Collider other)
    {
        gameManager = GameManager.instance;
        if (other.gameObject.tag == "Player")
        {
            gameManager.LoadScene(sceneIndex);
        }
    }
}
