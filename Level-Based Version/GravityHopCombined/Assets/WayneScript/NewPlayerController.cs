﻿using UnityEngine;
using System.Collections;

public class NewPlayerController : MonoBehaviour {

	//Key State Machine
	public CentralStateScript stateMachine;

	public float speed=1;
	public Vector2 MassCenter,WalkingDirection,BurstDirecton,LastMassCenter;
	private Rigidbody2D rg2d;
    private PointEffector2D CurrentPlanet, LastPlanet;
	private bool UFOEnableTouch = false, touchButton = true;

	//Audio portion of the code
	public AudioSource bouncingSound;

	/*Combo Portion of the code. It's unavoidable */
	public NewComboScript comboScript;

	// Use this for initialization
	void Start () {
        if (stateMachine == null)
            stateMachine = GameObject.FindGameObjectWithTag("SM").GetComponent<CentralStateScript>();
        Debug.Assert (stateMachine);

        rg2d = GetComponent<Rigidbody2D> ();
		rg2d.mass = 2;
		Vector2 initial_Dir = new Vector2 (-4, 1);
		rg2d.AddForce (7*initial_Dir.normalized, ForceMode2D.Impulse); //Initialize Movement
	}

	void FixedUpdate(){
		BurstDirecton = (rg2d.position - MassCenter).normalized;
		WalkingDirection = new Vector2 (-BurstDirecton.y, BurstDirecton.x);
	}

	// Update is called once per frame
	void Update () {
        if (stateMachine.getMovement() == CentralStateScript.Movement.Orbit && rg2d.velocity.magnitude > 3)
        {
            Debug.Log(rg2d.velocity);
            rg2d.velocity = 3 * rg2d.velocity.normalized;
        }

        DetectInput();
    }

	void DetectInput (){
		//Detect Input
		if ((Input.GetKeyDown ("up") || Input.touchCount > 0) && stateMachine.getGameState() != CentralStateScript.GameState.Victory) {

			if (touchButton) {
				touchButton = false;
			}
			if (UFOEnableTouch) {
                //Take flight
                CurrentPlanet.enabled = false;
                rg2d.velocity = BurstDirecton * 200;
//                rg2d.AddForce (BurstDirecton * 4000, ForceMode2D.Force);
				if (bouncingSound != null) {
					bouncingSound.Play ();
				}
				if (stateMachine) {
					stateMachine.enterFlight ();
				} else {
					Debug.Log ("State Machine does not exist");
					Application.Quit ();
				}
				UFOEnableTouch = false;
			}

		}

		if (rg2d.velocity.magnitude > 5)
			rg2d.velocity = rg2d.velocity.normalized * 5;
		if (rg2d.velocity.magnitude < 3)
			rg2d.velocity = rg2d.velocity.normalized * 3;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals ("Planet")) {
			Rigidbody2D coll_rg = coll.gameObject.GetComponent<Rigidbody2D> ();
			LastMassCenter = MassCenter;
			MassCenter = coll_rg.position;

			UFOEnableTouch = true;

            // grabs the rigidbody for planet landed on
            LastPlanet = CurrentPlanet;
            CurrentPlanet = coll.gameObject.GetComponent<PointEffector2D>();
            if (LastPlanet != null)
                LastPlanet.enabled = true;

            if (comboScript != null && MassCenter != LastMassCenter) {
				comboScript.Combo ();
				if (stateMachine) {
					stateMachine.enterOrbit ();
				} else {
					Debug.Log ("State Machine does not exist");
					Application.Quit ();
				}
			}
		}
	}

    void OnBecameInvisible()
    {
        stateMachine.GameOver();
    }
    
}
