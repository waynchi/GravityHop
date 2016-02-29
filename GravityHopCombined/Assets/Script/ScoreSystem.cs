﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSystem : MonoBehaviour {
    Text text;
    public int score;
    public int scoreMultiplier;
    public float timeMultiplier;

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
        score += 5 * scoreMultiplier;

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