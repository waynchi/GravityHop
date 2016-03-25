using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
	private Rigidbody2D rg2d;
	private PointEffector2D ef2d;
	private GameObject player;

	// Use this for initialization
	void Start () {
		rg2d = GetComponent<Rigidbody2D> ();
		ef2d = GetComponent<PointEffector2D> ();
		rg2d.mass = 30;
		ef2d.forceMagnitude = -rg2d.mass*2;

		if (GameObject.FindGameObjectWithTag ("Field") != null) {
			GameObject child = Instantiate (GameObject.FindGameObjectWithTag ("Field"), transform.position, transform.rotation) as GameObject;
			child.transform.localScale = child.transform.localScale * transform.localScale.x;
		}
        //child.transform
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {

		//coll.gameObject.SendMessage ("Combo");
	}



}
