using UnityEngine;
using System.Collections;
using System;

public class GameOverScript : MonoBehaviour {

	public float restartDelay = 1000f;

	Animator anim;
	float restartTimer;
	bool restart;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		restart = false;
	}
	
	// Update is called once per frame
	void Update () {
		restart = false;
		if (Input.GetKey ("g")) {
			while (!restart) {
				anim.SetTrigger ("GameOver");

				restartTimer += Time.deltaTime;

				if (restartTimer >= restartDelay) {
					Console.Out.WriteLine ("Test");
					UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex);
					//Application.LoadLevel (Application.loadedLevel);
				}
			}
		}
	}
}
