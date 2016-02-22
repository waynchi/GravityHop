using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	// Use this for initialization
	private Rigidbody2D rigidBody;
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("up")) {
			Vector2 v = rigidBody.velocity;
			v.y = 5;
			rigidBody.velocity = v;
		} else if (Input.GetKey ("down")) {
			Vector2 v = rigidBody.velocity;
			v.y = -5;
			rigidBody.velocity = v;
		} else if (Input.GetKey ("left")) {
			Vector2 v = rigidBody.velocity;
			v.x = -5;
			rigidBody.velocity = v;
		} else if (Input.GetKey ("right")) {
			Vector2 v = rigidBody.velocity;
			v.x = 5;
			rigidBody.velocity = v;
		} else {
			Vector2 v = rigidBody.velocity;
			v.y = 0;
			v.x = 0;
			rigidBody.velocity = v;
		}
	}
}
