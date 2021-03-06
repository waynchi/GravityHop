﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	int numOfLevels = 15;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numOfLevels; i++) {
			if (!PlayerPrefs.HasKey ("Level"+(i+1).ToString())) {
				PlayerPrefs.SetInt ("Level" + (i+1).ToString(), 0);
			}
		}


	}

	void Update () {
		if (Input.GetKey ("r")) {
			PlayerPrefs.DeleteAll ();
			SceneManager.LoadScene (0);
		}
	}


    public void LoadLevel(int level)
	{
		// BuildIndex
		// 0: Start Screen
		// 1: level1
		SceneManager.LoadScene(level);
	}

    public void ClearGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
