using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelClear : MonoBehaviour {
    //central state machine
    public CentralStateScript stateMachine;
    Animator anim;
    bool displayScore;
    // Use this for initialization
    void Start () {
        if (stateMachine == null)
            stateMachine = GameObject.FindGameObjectWithTag("SM").GetComponent<CentralStateScript>();
        anim = GetComponent<Animator>();
        displayScore = false;

    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKey ("w")) {
			stateMachine.Victory ();
		}
        if (displayScore == false && stateMachine.getGameState() == CentralStateScript.GameState.Victory)
        {
            LevelCleared();
            displayScore = true;
        }
	}

    void LevelCleared()
    {
		anim.SetTrigger("LevelCleared");
    }

    public void NextLevel()
    {

		SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
    }

	public void StartMenu()
	{
		SceneManager.LoadScene(0);
	}
}
