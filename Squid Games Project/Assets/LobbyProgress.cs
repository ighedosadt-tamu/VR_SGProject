using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyProgress : MonoBehaviour
{
    [SerializeField]
    private string[] roomDialogue;

    [SerializeField]
    private TextMeshProUGUI roomText;
    private GameManager gm;

    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
        if(gm.completedRooms > 0 || gm.IsStateCompleted(GameManager.State.completedHaptics) || 
            gm.IsStateCompleted(GameManager.State.completedInteraction) || 
            gm.IsStateCompleted(GameManager.State.completedNavigation) ||
            gm.IsStateCompleted(GameManager.State.completedPassthrough)){
            roomText.text = roomDialogue[0];
        }
            
        if(gm.completedRooms == 4 || (gm.IsStateCompleted(GameManager.State.completedHaptics) && 
            gm.IsStateCompleted(GameManager.State.completedInteraction) && 
            gm.IsStateCompleted(GameManager.State.completedNavigation) &&
            gm.IsStateCompleted(GameManager.State.completedPassthrough)))
            roomText.text = roomDialogue[1];
    }
}
