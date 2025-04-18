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
    public Animator animator;
    bool isInteracting;
    
    private void Start()
    {
        if (roomDialogue == null)
        {
            Debug.LogWarning("Need to add dialogue lines for the friendly NPC in each room.");
            return;
        }
        uiCanvas.gameObject.SetActive(false);
       
    }
    
    private void Update()
    {
        BillboardEffect(uiCanvas.gameObject);

    }

    private void BillboardEffect(GameObject current_game_object)
    {
        Vector3 direction = current_game_object.transform.position - playerCam.transform.position;
        direction.y = 0f; // prevent tilting up/down
        current_game_object.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    public void StartInteraction(bool inZone)
    {
        isInteracting = inZone;
        animator.SetBool("Start", inZone);
        if (inZone)
        {
            SetDialogue(roomDialogue[0]);
            uiCanvas.gameObject.SetActive(true);
        }
        if (!isInteracting)
        {
            SetDialogue("");
            uiCanvas.gameObject.SetActive(false);
        }
       
    }

    public void SetDialogue(string line)
    {
        uiText.text = line;

    }
}
