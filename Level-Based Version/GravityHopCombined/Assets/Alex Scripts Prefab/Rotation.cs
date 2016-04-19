using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
    Rigidbody2D rg2d;

	// Use this for initialization
	void Start () {
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        rg2d.angularVelocity = -30.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
