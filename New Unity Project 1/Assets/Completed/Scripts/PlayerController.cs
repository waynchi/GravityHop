using UnityEngine;
using System.Collections;



public class PlayerController : MonoBehaviour {

	public float speed;
	public float NewTonPara;
	private float initX = 4,initY=3;
	public bool Flag_A = true;
	private Rigidbody2D rg2d;

	void Start()
	{
		rg2d = GetComponent<Rigidbody2D> ();
		rg2d.position = new Vector2 (initX, initY);
		Vector2 initCircling = new Vector2 (initY, -initX);
		rg2d.AddForce (initCircling, ForceMode2D.Impulse);
	}

	void FixedUpdate()
	{

		if (Input.GetKey ("left"))
			speed = 0;

		Vector2 UniversalGravitation = new Vector2 (-1 * rg2d.position.x, -1 * rg2d.position.y);
		rg2d.AddForce (UniversalGravitation*speed);

		if (Input.GetKey ("up")) {
			float perpenX = rg2d.position.y;
			float perpenY = -rg2d.position.x;
			Vector2 perpendicular = new Vector2 (perpenX, perpenY);


			rg2d.AddForce (perpendicular * speed);
		}

		if (Input.GetKey ("down")) {
			float perpenX = -rg2d.position.y;
			float perpenY = rg2d.position.x;
			Vector2 perpendicular = new Vector2 (perpenX, perpenY);


			rg2d.AddForce (perpendicular * speed);

		}

	}


}
