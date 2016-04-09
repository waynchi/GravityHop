using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSystem : MonoBehaviour {


    Text text;
    public int score;
    public int scoreMultiplier;
    public float timeMultiplier;

	public bool stop; 

    public void addMultiplier()
    {
        ++scoreMultiplier;
        timeMultiplier = 0;
    }

    public void addScore(int num)
    {
        score += num * scoreMultiplier;
    }
    
    // Use this for initialization
    void Start () {
        stop = true;
        text = GetComponent<Text>();
        score = 0;
        scoreMultiplier = 1;
        timeMultiplier = 0;
        InvokeRepeating("UpdateScore", 0, 0.1f);
    }
	
	// Update is called once per frame
	void UpdateScore () {
        // set the text with score
        text.text = "" + score;
		if (!stop) {
			score += 5 * scoreMultiplier;
		}
		if (!stop) {
			if(scoreMultiplier > 1)
			{
				timeMultiplier += Time.deltaTime;
				if (timeMultiplier > 10) // time of multiplier is 10 seconds
				{
					scoreMultiplier = 1; // multiplier is back to normal
					timeMultiplier = 0;
				}
			}
		}
        
	}

	public void StopGame() {
		stop = true;
	}

	public void StartGame() {
		stop = false;
	}

}
