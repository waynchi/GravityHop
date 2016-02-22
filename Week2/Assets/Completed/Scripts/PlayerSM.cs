using UnityEngine;
using System.Collections;

public class PlayerSM : MonoBehaviour {

    public enum PlayerState {ORBIT, LAUNCH, GAMEOVER}

    public PlayerState currentState;

	// Use this for initialization
	void Start () {
        currentState = PlayerState.ORBIT;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("left")) {
            currentState = PlayerState.LAUNCH;
        }
        else if (Input.GetKey("right"))
        {
            currentState = PlayerState.ORBIT;
        }
    }
}
