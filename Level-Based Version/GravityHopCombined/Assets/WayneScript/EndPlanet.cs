using UnityEngine;
using System.Collections;

public class EndPlanet : MonoBehaviour {

	public CentralStateScript stateMachine;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals ("Player")) {
			stateMachine.Victory ();
		}
	}
}
