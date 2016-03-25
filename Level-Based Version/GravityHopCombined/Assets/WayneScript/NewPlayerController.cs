using UnityEngine;
using System.Collections;

public class NewPlayerController : MonoBehaviour {

	public float speed=1;
	public Vector2 MassCenter,WalkingDirection,BurstDirecton,LastMassCenter;
	private Rigidbody2D rg2d;
	private bool UFOEnableTouch = false, touchButton = true;

	//Audio portion of the code
	public AudioSource bouncingSound;

	/*Combo Portion of the code. It's unavoidable */
	public NewComboScript comboScript;

	// Use this for initialization
	void Start () {
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
		DetectInput ();
	}

	void DetectInput (){
		//Detect Input
		if (Input.GetKeyDown ("up")) {

			if (touchButton) {
				touchButton = false;
			}
			if (UFOEnableTouch) {
				//Take flight
				rg2d.AddForce (BurstDirecton * 4000, ForceMode2D.Force);
				if (bouncingSound != null) {
					bouncingSound.Play ();
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
			if (comboScript != null && MassCenter != LastMassCenter) {
				comboScript.Combo ();
			}
		}
	}

}
