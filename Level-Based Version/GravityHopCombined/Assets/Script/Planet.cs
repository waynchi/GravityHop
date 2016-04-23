using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
	private Rigidbody2D rg2d;
	private PointEffector2D ef2d;
	private GameObject player;
    private GameObject field;

	// Use this for initialization
	void Start () {
		rg2d = GetComponent<Rigidbody2D> ();
		ef2d = GetComponent<PointEffector2D> ();
		rg2d.mass = 30;
		ef2d.forceMagnitude = -rg2d.mass*2;

        // instantiate the visibility of gravity fields
        field = Instantiate(Resources.Load("Gravity Field"), transform.position, transform.rotation) as GameObject;
        CircleCollider2D[] cc2d = ef2d.GetComponents<CircleCollider2D>();
        field.transform.localScale = field.transform.localScale * transform.localScale.x * cc2d[1].radius;

        if (gameObject.name == "StartPlanet")
        {
            Instantiate(Resources.Load("UFO"), transform.position + new Vector3(0, transform.localScale.x * 0.5f, 0), transform.rotation);
        }

    }

    // Update is called once per frame
    void Update () {
        field.transform.position = transform.position;		
	}

	void OnCollisionEnter2D(Collision2D coll) {

		//coll.gameObject.SendMessage ("Combo");
	}



}
