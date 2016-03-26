using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class NewGameOverScript : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("g")) {
            GameOver();
		}
		if (Input.GetKey ("r")) {
            Restart();
        }
	}

    public void GameOver()
    {
        anim.SetTrigger("GameOver");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
