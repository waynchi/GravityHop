using UnityEngine;
using System.Collections;

public class Rotating : MonoBehaviour {

    Rigidbody2D rb2d;
    public float angularSpeed = -20;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.angularVelocity = angularSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
