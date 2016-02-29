using UnityEngine;
using System.Collections;
using System;

public class GameOverScript : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("g")) {
			anim.SetTrigger ("GameOver");
		}
		if (Input.GetKey ("r")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex);
		}
	}
}
