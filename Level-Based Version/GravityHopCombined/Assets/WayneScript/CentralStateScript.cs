using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//This script will hold all the states for everything in the 
public class CentralStateScript : MonoBehaviour {

	//Score
	private int currentScore;

	//All enums are here
	public enum Movement{Orbit, Flight};
	public enum GameState{GameOver, Start, Playing, Victory};

	//All states are here
	Movement myMovement;
	GameState myGameState; 

	// Use this for initialization
	void Start () {
		myMovement = Movement.Orbit;
		myGameState = GameState.Start;
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Called to change movement to Flying;
	public void enterFlight() {
		myMovement = Movement.Flight;
	}
		
	//Called to change movement to Orbit;
	public void enterOrbit() {
		myMovement = Movement.Orbit;
	}

	public Movement getMovement() {
		return myMovement;
	}
		
	public void GameOver() {
		myGameState = GameState.GameOver;
	}

    // gets the game state
    public GameState getGameState()
    {
        return myGameState;
    }

	//Called when a victory is achieved
	public void Victory() {
		myGameState = GameState.Victory;
	}

	public void updateScore(int score) {
		currentScore = score;
	}

	public int getScore() {
		return currentScore;
	}

}
