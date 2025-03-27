using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationGM : MonoBehaviour
{
    public float timeLimitItemPickup = 180f; // Time limit in seconds to pick up items
    public ItemPickup itemPickup;
    public TMPro.TextMeshProUGUI timerText;
    public TMPro.TextMeshProUGUI resultText;
    
    public GameObject lobbyPortal;

    private bool collectedItems = false;
    private float timeRemaining;
    public bool completedLevel;

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
        while (timeRemaining > 0 && !collectedItems)
        {
            UpdateTimerDisplay();
            timeRemaining -= 1f;
            yield return new WaitForSeconds(1f);
            
        }

            
        if (!collectedItems)
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
        if (itemPickup.GetItemsCollected() < itemPickup.totalItems)
        {
            Debug.Log("You didn't collect all of the items.");
            resultText.text = "You didn't collect all of the items.";
            completedLevel = false;
        }
        else if (itemPickup.GetItemsCollected() == itemPickup.totalItems)
        {
            collectedItems = true;
            Debug.Log("Cognratualions! All items collected!");
            resultText.text = "Congratulations! All items collected!";
            completedLevel = true;
            
        }

    }
    
    public bool RanOutOfTime()
    {
        return timeRemaining <= 0;
    }
}
