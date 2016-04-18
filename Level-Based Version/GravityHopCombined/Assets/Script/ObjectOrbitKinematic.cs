using UnityEngine;
using System.Collections;

public class ObjectOrbitKinematic : MonoBehaviour {
	public GameObject center;
	public float AngularSpeed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*
		c_rg2d = center.GetComponent<Rigidbody2D> ();
		transform.RotateAround (c_rg2d.position, Vector3.forward, AngularSpeed * Time.deltaTime);
		*/
	}
}
