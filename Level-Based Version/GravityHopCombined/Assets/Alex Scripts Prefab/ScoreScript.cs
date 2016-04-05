using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {
    Text text;
    public int score;
    public int scoreMultiplier;
    public Canvas HUDCanvas;
    TimerScript time;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        if (HUDCanvas == null)
            HUDCanvas = GameObject.FindGameObjectWithTag("HUD").GetComponent<Canvas>();

        score = 0;
        scoreMultiplier = 1;

        Transform t = HUDCanvas.transform.FindChild("Timer");
        time = t.gameObject.GetComponent<TimerScript>();
        InvokeRepeating("UpdateScore", 0, 0.1f);
    }

    // Update is called once per frame
    void UpdateScore()
    {
        Transform t = HUDCanvas.transform.FindChild("Timer");
        time = t.gameObject.GetComponent<TimerScript>();

        // set the text with score
        int sec = (int)(time.getTime() * 10.0f);
        text.text = "Score: " + sec * 10;
    }

}

