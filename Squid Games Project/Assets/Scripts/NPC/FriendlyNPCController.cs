using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FriendlyNPCController : MonoBehaviour
{
    public List<string> roomDialogue = new List<string>();
    public TextMeshProUGUI uiText;
    public Canvas uiCanvas;
    public GameObject playerCam;
    public Animator animator;
    bool isInteracting;
    [NonSerialized] public int dialogue_index = 0;
    GameManager gameManager;

    private void Start()
    {
        if (roomDialogue == null)
        {
            Debug.LogWarning("Need to add dialogue lines for the friendly NPC in each room.");
            return;
        }
        uiCanvas.gameObject.SetActive(false);
         
        gameManager = GameManager.instance;
        if (gameManager.completedRooms == 4)
        {
            roomDialogue.Clear();
            roomDialogue.Add("Congratulations you fixed the dream states!");
            roomDialogue.Add("Thanks for playing!");
        }

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
            SetDialogue(roomDialogue[dialogue_index]);
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

    public void ContinueDialogue()
    {
        Debug.Log("Clicked Button");
        dialogue_index += 1;
        if (dialogue_index < roomDialogue.Count)
        {
            SetDialogue(roomDialogue[dialogue_index]);
        }
        else
        {
            if (isInteracting)
            {
                uiCanvas.gameObject.SetActive(false);
            }
            dialogue_index = 0;
            SetDialogue(roomDialogue[dialogue_index]);
        }
    }
}
