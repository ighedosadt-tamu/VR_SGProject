using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FriendlyNPCController : MonoBehaviour
{
    public string[] roomDialogue = new string[5];
    public TextMeshProUGUI uiText;
    public Canvas uiCanvas;
    public GameManager gameManager;
    public GameObject playerCam;

    private void Start()
    {
        if (roomDialogue == null)
        {
            Debug.LogWarning("Need to add dialogue lines for the friendly NPC in each room.");
            return;
        }
        SetDialogue(roomDialogue[0]);
    }
    
    private void Update()
    {
        UiBillboard();
    }

    private void UiBillboard()
    {
        Vector3 direction = uiCanvas.transform.position - playerCam.transform.position;
        direction.y = 0f; // prevent tilting up/down
        uiCanvas.transform.rotation = Quaternion.LookRotation(direction);
    }

    public void SetDialogue(string line)
    {
        uiText.text = line;

    }
}
