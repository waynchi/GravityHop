using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
	private Rigidbody2D rg2d;
	private PointEffector2D ef2d;

	// Use this for initialization
	void Start () {
		rg2d = GetComponent<Rigidbody2D> ();
		ef2d = GetComponent<PointEffector2D> ();
		rg2d.mass = 400;
		ef2d.forceMagnitude = -rg2d.mass;
		rg2d.freezeRotation = true;

        GameObject child = Instantiate(GameObject.FindGameObjectWithTag("Field"), transform.position, transform.rotation) as GameObject;
        child.transform.localScale = child.transform.localScale * transform.localScale.x;
        //child.transform
    }
	
	// Update is called once per frame
	void Update () {
		rg2d.angularVelocity = 0;
	}
}
