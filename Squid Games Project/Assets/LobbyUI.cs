using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyUI : MonoBehaviour
{
    [SerializeField]
    private string[] roomDialogue;
    [SerializeField]
    private TextMeshProUGUI roomText;
    private int dialogue_index = 0;

    [SerializeField]
    private GameObject continueButton;
    [SerializeField]
    private GameObject backButton;
    [SerializeField]
    private GameManager gm;

    [SerializeField]
    private GameObject startingCanvas;
    [SerializeField]
    private GameObject progressCanvas;

    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
        if(gm.completedRooms > 0 || gm.IsStateCompleted(GameManager.State.completedHaptics) || 
            gm.IsStateCompleted(GameManager.State.completedInteraction) || 
            gm.IsStateCompleted(GameManager.State.completedNavigation) ||
            gm.IsStateCompleted(GameManager.State.completedPassthrough)){
                progressCanvas.SetActive(true);
                startingCanvas.SetActive(false);
            }
            
    }

    public void ContinueDialogue()
    {
        dialogue_index += 1;
        if (dialogue_index < roomDialogue.Length)
        {
            roomText.text = roomDialogue[dialogue_index];
            if(roomDialogue.Length - 1 == dialogue_index)
                continueButton.SetActive(false);
            else
                continueButton.SetActive(true);

            if(dialogue_index > 0)
                backButton.SetActive(true);
            else
                backButton.SetActive(false);
        }
        else
        {
            dialogue_index = roomDialogue.Length - 1;
            roomText.text = roomDialogue[dialogue_index];
            continueButton.SetActive(false);
        }
    }

    public void BackDialogue()
    {
        dialogue_index -= 1;
        if (dialogue_index >= 0)
        {
            roomText.text = roomDialogue[dialogue_index];
            if(roomDialogue.Length - 1 == dialogue_index)
                continueButton.SetActive(false);
            else
                continueButton.SetActive(true);

            if(dialogue_index > 0)
                backButton.SetActive(true);
            else
                backButton.SetActive(false);
        }
        else
        {
            dialogue_index = 0;
            roomText.text = roomDialogue[dialogue_index];
            backButton.SetActive(false);
        }
    }
}
