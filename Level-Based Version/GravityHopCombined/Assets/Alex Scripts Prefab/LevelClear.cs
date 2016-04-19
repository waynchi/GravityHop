using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
		int level = SceneManager.GetActiveScene().buildIndex;
		int stars = 0;
		//A different scoring requirement for each level
		switch (level) {
		case 1: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 2: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 3: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 4: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 5: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 6: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 7: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 8: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 9: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 10: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 11: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 12: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 13: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 14: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 15: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		default:
			stars = 0;
			break;
		}
		if (PlayerPrefs.GetInt ("Level" + level.ToString ()) < stars) {
			PlayerPrefs.SetInt ("Level" + (level).ToString (), stars);
		}

		// Changing Sprite image
		Sprite starSprite;

		switch (stars) {

		case 0:
			starSprite = Resources.Load<Sprite> ("three_stars_empty");
			break;
		case 1:
			starSprite = Resources.Load<Sprite> ("one_star");
			break;
		case 2:
			starSprite = Resources.Load<Sprite> ("two_stars");
			break;
		case 3:
			starSprite = Resources.Load<Sprite> ("three_stars");
			break;
		default:

			starSprite = Resources.Load<Sprite> ("three_stars_empty");
			break;
		}

		GameObject.Find ("Stars").GetComponent<Image> ().sprite = starSprite;

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
