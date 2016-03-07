using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
	private Rigidbody2D rg2d;
	private PointEffector2D ef2d;

	// Use this for initialization
	void Start () {
		rg2d = GetComponent<Rigidbody2D> ();
		ef2d = GetComponent<PointEffector2D> ();
		rg2d.mass = 100;
		ef2d.forceMagnitude = -rg2d.mass;
		rg2d.freezeRotation = true;

	}
	
	// Update is called once per frame
	void Update () {
		rg2d.angularVelocity = 0;
	}
}
