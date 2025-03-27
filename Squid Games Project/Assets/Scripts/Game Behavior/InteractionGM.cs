using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGM : MonoBehaviour
{
    public float timeLimit = 180f; // Time limit in seconds to pick up items
    public ItemPickup itemPickup;
    public TMPro.TextMeshProUGUI timerText;
    public TMPro.TextMeshProUGUI resultText;
    public GameObject lobbyPortal;

    public bool levelDone = false;
    private bool roomDone = false;
    private float timeRemaining;
    public bool completedLevel = false;
    // Start is called before the first frame update
    void Start()
    {
        lobbyPortal.SetActive(false);
        timeRemaining = timeLimit;
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        while (timeRemaining > 0 && !roomDone)
        {
            UpdateTimerDisplay();
            timeRemaining -= 1f;     
            yield return new WaitForSeconds(1f);
            
        }

            
        if (!roomDone)
        {
            UpdateTimerDisplay();
            CheckItemPickupTimeLimit();
        }
        
       
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void CheckItemPickupTimeLimit()
    {
        lobbyPortal.SetActive(true);
        if (!levelDone)
        {
            Debug.Log("You didn't finish the puzzle.");
            resultText.text = "You didn't finish the puzzle.";
            completedLevel = false;
        }
        else
        {
            roomDone = true;
            Debug.Log("Cognratualions! You fixed the rift!");
            resultText.text = "Congratulations! You fixed the rift!";
            completedLevel = true;
        }
    }

    public bool RanOutOfTime()
    {
        return timeRemaining <= 0;
    }
}
