using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private bool door_close = false;
    public GameObject doorPivot;
    [SerializeField] SceneBehavior sceneBehavior;
    [SerializeField] int nextSceneIndex = 0;

    private void OnTriggerEnter(Collider other) {
        string tag = other.gameObject.tag;

        if (tag == "Player" && !door_close)
        {
            
            door_close = true;
            doorPivot.GetComponent<Animation>().Play("DoorClose");

            StartCoroutine(DelayScene());
        }
    }
    IEnumerator DelayScene()
    {
        yield return new WaitForSeconds(5f);
        sceneBehavior.NextScene(nextSceneIndex);
    }
}
