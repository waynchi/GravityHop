using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public CentralStateScript stateMachine;
    Text text;
    public int totalScore;
	public int timeScore;
	public int coinScore;
    public int scoreMultiplier;
    public Canvas HUDCanvas;
    TimerScript time;

    // Use this for initialization
    void Start()
    {
		if (stateMachine == null)
			stateMachine = GameObject.FindGameObjectWithTag("SM").GetComponent<CentralStateScript>();
        text = GetComponent<Text>();
        if (HUDCanvas == null)
            HUDCanvas = GameObject.FindGameObjectWithTag("HUD").GetComponent<Canvas>();

		totalScore = 0;
		timeScore = 0;
		coinScore = 0;
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
		timeScore = sec * 10;
		totalScore = timeScore + coinScore;
		text.text = "Score: " + totalScore;
		stateMachine.updateScore (totalScore);

    }

	public void addScore(int num)
	{
		coinScore += num * scoreMultiplier;
	}

	public void addMultiplier()
	{
		++scoreMultiplier;
		//timeMultiplier = 0;
	}
}

