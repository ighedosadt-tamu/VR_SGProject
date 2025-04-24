using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PassthroughManager : MonoBehaviour
{
    public OVRPassthroughLayer layer;
    private bool op = true;
    public InputActionProperty selectButton;
    private bool passthroughActive = false;


    public float timeLimitItemPickup = 180f; // Time limit in seconds to pick up items
    public GhostKill ghostKill;
    public TMPro.TextMeshProUGUI timerText;
    public TMPro.TextMeshProUGUI resultText;
    
    public GameObject lobbyPortal;

    private bool ghostKilled = false;
    public float timeRemaining;
    public bool completedLevel;

    // Start is called before the first frame update
    void Start()
    {
        lobbyPortal.SetActive(false);
        timeRemaining = timeLimitItemPickup;
        StartCoroutine(CountdownTimer());
        completedLevel = false;
        layer.textureOpacity = 0.0f;
    }

    IEnumerator CountdownTimer()
    {
        while (timeRemaining > 0 && !ghostKilled)
        {
            UpdateTimerDisplay();
            timeRemaining -= 1f;
            yield return new WaitForSeconds(1f);
        }
        if (!ghostKilled)
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
        if (ghostKill.GetGhostCollected() < ghostKill.totalItems)
        {
            resultText.text = "Game Over. You got caught by a ghost!";
            completedLevel = false;
        }
        else if (ghostKill.GetGhostCollected() == ghostKill.totalItems)
        {
            ghostKilled = true;
            resultText.text = "Congratulations! All ghosts defeated!";
            completedLevel = true;
        }

    }
    
    public bool RanOutOfTime()
    {
        return timeRemaining <= 0;
    }

    void Update()
    {
        if (selectButton.action.WasPressedThisFrame() && !passthroughActive)
        {
            passthroughActive = true;
            StartCoroutine(changeOpacity());
        }
    }


    IEnumerator changeOpacity(){
        layer.textureOpacity = 1.0f;
        yield return new WaitForSeconds(1f);
        layer.textureOpacity = 0.0f;
        yield return new WaitForSeconds(1f);
        passthroughActive = false;
    }
    
    public void ChangeOpacity()
    {
        if (!op)
        {
            layer.textureOpacity = 1;
            op = true;
        }
        else
        {
            layer.textureOpacity = 0.0f;
            op = false;
        }
    }
}
