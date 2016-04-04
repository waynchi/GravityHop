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
        if (displayScore == false && stateMachine.getGameState() == CentralStateScript.GameState.Victory)
        {
            LevelCleared();
            displayScore = true;
        }
	}

    public void LevelCleared()
    {
        Debug.Log("HELLO");
        anim.SetTrigger("LevelCleared");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
