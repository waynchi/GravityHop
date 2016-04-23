using UnityEngine;
using System.Collections;

public class StopGravity : MonoBehaviour {

	Rigidbody2D rg2d;

	// Use this for initialization
	void Start () {
		rg2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rg2d.gravityScale = 0;
	}
}
