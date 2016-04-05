using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

	public float speed=1;
	public float fuel = 100;
	public Vector2 MassCenter,WalkingDirection,BurstDirecton,LastMassCenter;
	private Rigidbody2D rg2d;
	private bool UFOEnableTouch = false,started = true, touchButton = true;

	public bool ComboInitiated = false;
	public float lastComboTime = 0.0F;
	public float ComboCount = 0,comboTime = 3;
	public string displayComboContent; 

	public Text DisplayCombo;
	public AudioSource bouncingSound;



	void Start()
	{

		rg2d = GetComponent<Rigidbody2D> ();
		rg2d.mass = 2;
		Vector2 initial_Dir = new Vector2 (-4, 1);
		rg2d.AddForce (7*initial_Dir.normalized, ForceMode2D.Impulse); //Initialize Movement

	}

	void FixedUpdate(){
		BurstDirecton = (rg2d.position - MassCenter).normalized;
		WalkingDirection = new Vector2 (-BurstDirecton.y, BurstDirecton.x);
	}

	void Update()
	{
		if(started)
			DetectInput ();
	/*	Vector2 UniversalGravitation = DetectForceObject ();
		rg2d.AddForce (UniversalGravitation*speed);
	*/
		DisplayCombo.text = displayComboContent;
			
	}


	void DetectInput (){
/*
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Ended){

				if (touchButton) {
					touchButton = false;
					continue;
				}
				if (fuel > 0 && UFOEnableTouch) {
					rg2d.AddForce (BurstDirecton * 4000, ForceMode2D.Force);
					bouncingSound.Play ();
					UFOEnableTouch = false;
				}
				//if(fuel>0)
				//fuel -= touch.deltaPosition.magnitude/10;

			}
		}
	*/

		if (Input.GetKeyDown("up")){

				if (touchButton) {
					touchButton = false;
				}
				if (fuel > 0 && UFOEnableTouch) {
					rg2d.AddForce (BurstDirecton * 4000, ForceMode2D.Force);
					bouncingSound.Play ();
					UFOEnableTouch = false;
				}
				//if(fuel>0)
				//fuel -= touch.deltaPosition.magnitude/10;

			}

		if (rg2d.velocity.magnitude > 5)
			rg2d.velocity = rg2d.velocity.normalized * 5;
		if (rg2d.velocity.magnitude < 3)
			rg2d.velocity = rg2d.velocity.normalized * 3;
		if (Time.time - lastComboTime > comboTime) {
			ComboInitiated = false;
			ComboCount = 0;
			displayComboContent = "";
		}

	}
		
	//Check collision with a planet, and get the burtst direction.
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals ("Planet")) {
			Rigidbody2D coll_rg = coll.gameObject.GetComponent<Rigidbody2D> ();
			LastMassCenter = MassCenter;
			MassCenter = coll_rg.position;
	
			UFOEnableTouch = true;
		}
	}

	void GameStart(){
		started = true;
	}

	void Combo(){
		if (started) {

			if (ComboInitiated) {
				if (Time.time - lastComboTime > comboTime) {
					ComboInitiated = false;
					ComboCount = 0;
					displayComboContent = "";
				} else {
					if (!MassCenter.Equals (LastMassCenter)) {
						ComboCount++;
						lastComboTime = Time.time;
						displayComboContent = "Combo: " + ComboCount.ToString () + "  !!!";
					}
				}

			} else {
				if (!MassCenter.Equals (LastMassCenter)) {
					ComboInitiated = true;
					ComboCount = 1;
					lastComboTime = Time.time;
					displayComboContent = "Combo: " + ComboCount.ToString () + "  !!!";
				}
			}
		}

	}
/*

	void Landed () {
		isLanded = true;
		ForceGiven = false;
		if(!ForceGiven)rg2d.velocity = rg2d.velocity * 0;
	}

*/
}
