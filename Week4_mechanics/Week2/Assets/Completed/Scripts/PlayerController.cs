using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	public float speed=1;
	public float fuel = 100;
	public Vector2 MassCenter,WalkingDirection,BurstDirecton;
	private Rigidbody2D rg2d;
	private bool UFOEnableTouch = false,started = false, touchButton = true;



	void Start()
	{

		rg2d = GetComponent<Rigidbody2D> ();
		rg2d.mass = 2;
		rg2d.AddForce (2*rg2d.position, ForceMode2D.Impulse); //Initialize Movement

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
	
	}


	void DetectInput (){

		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Ended){

				if (touchButton) {
					touchButton = false;
					continue;
				}
				if (fuel > 0 && UFOEnableTouch) {
					rg2d.AddForce (BurstDirecton * 1500, ForceMode2D.Force);
				}
				//if(fuel>0)
				//fuel -= touch.deltaPosition.magnitude/10;
				UFOEnableTouch = false;
			}
		}
		if (rg2d.velocity.magnitude > 50)
			rg2d.velocity = rg2d.velocity.normalized * 10;
		if (rg2d.velocity.magnitude < 10)
			rg2d.velocity = rg2d.velocity.normalized * 10;

	}
		

	void OnCollisionEnter2D(Collision2D coll) {

		Rigidbody2D coll_rg = coll.gameObject.GetComponent<Rigidbody2D> ();
		MassCenter = coll_rg.position;
		UFOEnableTouch = true;
	}

	void GameStart(){
		started = true;
	}
/*

	void Landed () {
		isLanded = true;
		ForceGiven = false;
		if(!ForceGiven)rg2d.velocity = rg2d.velocity * 0;
	}

*/
}
