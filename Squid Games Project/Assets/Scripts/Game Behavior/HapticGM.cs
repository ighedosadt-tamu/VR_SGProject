using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticGM : MonoBehaviour
{
    public float timeLimitItemPickup = 180f; // Time limit in seconds to pick up items
    public TMPro.TextMeshProUGUI timerText;
    public TMPro.TextMeshProUGUI resultText;
    GameManager gameManager;
    public GameObject lobbyPortal;

    private float timeRemaining;
    public bool completedLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        lobbyPortal.SetActive(false);
        timeRemaining = timeLimitItemPickup;
        StartCoroutine(CountdownTimer());
        completedLevel = false;
    }

    IEnumerator CountdownTimer()
    {
        while (timeRemaining > 0 && !completedLevel)
        {
            UpdateTimerDisplay();
            timeRemaining -= 1f;
            yield return new WaitForSeconds(1f);
            
        }

            
        if (!completedLevel)
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
        if (!completedLevel)
        {
            resultText.text = "You ran out of time.";
        }
        else
        {
            gameManager = GameManager.instance;
            gameManager.completedRooms += 1;
            resultText.text = "You escaped the maze!";
        }

    }
    
    public bool RanOutOfTime()
    {
        return timeRemaining <= 0;
    }
}
