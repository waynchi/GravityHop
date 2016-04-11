using UnityEngine;
using System.Collections;

public class MoveOrbitKinematic : MonoBehaviour {

	public Vector2 TargetCenter;
	public float AngularSpeed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (TargetCenter, Vector3.forward, AngularSpeed * Time.deltaTime);
	}
}
