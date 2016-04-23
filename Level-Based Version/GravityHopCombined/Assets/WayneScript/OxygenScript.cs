using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OxygenScript : MonoBehaviour {

	//central state machine
	public CentralStateScript stateMachine;

	Image OxygenBar;
	public float maxOxygen = 5.0f;

	// Use this for initialization
	void Start () {
        if (stateMachine == null)
            stateMachine = GameObject.FindGameObjectWithTag("SM").GetComponent<CentralStateScript>();

        OxygenBar = GetComponent<Image> ();

		//Assertions
		Debug.Assert (stateMachine);
		Debug.Assert (OxygenBar);
	}
	
	// Update is called once per frame
	void Update () {
		if (stateMachine.getMovement () == CentralStateScript.Movement.Flight) {
			OxygenBar.fillAmount -= 1.0f / maxOxygen * Time.deltaTime;
		} else if (stateMachine.getMovement () == CentralStateScript.Movement.Orbit) {
			OxygenBar.fillAmount += 1.0f * Time.deltaTime;
		}

		if (OxygenBar.fillAmount <= 0) {
			stateMachine.GameOver ();
		}
	}
}
