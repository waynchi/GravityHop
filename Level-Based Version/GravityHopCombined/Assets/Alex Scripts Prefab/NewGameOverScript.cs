using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class NewGameOverScript : MonoBehaviour {

	Animator anim;
    public CentralStateScript stateMachine;
    bool isGameOver;

    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator> ();
        isGameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("g")) {
            GameOver();
		}
		if (Input.GetKey ("r")) {
            Restart();
        }
        if (!isGameOver && stateMachine.getGameState() == CentralStateScript.GameState.GameOver)
        {
            GameOver();
            isGameOver = true;
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
