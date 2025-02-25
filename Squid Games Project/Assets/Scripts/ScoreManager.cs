using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TMPro.TextMeshProUGUI txt;
    public Image scoreBar;
    public SceneBehavior sceneBehavior;

    public GameObject doorPivot;
    private bool door_opened = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        txt.text = "Score: " + score.ToString();
        scoreBar.fillAmount = score / 4f;

        if (score == 4)
        {
            if (!door_opened)
            {
                doorPivot.GetComponent<Animation>().Play("DoorOpen");
                door_opened = true;
            }
            
        }
    }
}
