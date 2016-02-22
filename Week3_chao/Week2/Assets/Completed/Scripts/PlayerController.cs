using UnityEngine;
using System.Collections;



public class PlayerController : MonoBehaviour {

	public float speed=1;
	public float NewTonPara;
	private float initX = 2,initY=1.5f;
	public bool needAntiV = true;
    public Rigidbody2D planet;
	public ArrayList MassList = new ArrayList();
	public Vector2 MassCenter;
	private Rigidbody2D rg2d;

	void Start()
	{
		rg2d = GetComponent<Rigidbody2D> ();
		rg2d.position = new Vector2 (initX, initY);
		Vector2 initCircling = new Vector2 (-initY, initX);
		setUpPlanets ();
		rg2d.AddForce (initCircling, ForceMode2D.Impulse);
	}

	void FixedUpdate()
	{
		DetectInput ();
		Vector2 UniversalGravitation = DetectForceObject ();
		rg2d.AddForce (UniversalGravitation*speed);

	}

	void setUpPlanets (){
		MassList.Add (new Vector2 (0, 0));
		MassList.Add (new Vector2 (13, 13));
		MassList.Add (new Vector2 (-20.1f, 6.4f));
		MassList.Add (new Vector2 (-20, -7.2f));
		MassList.Add (new Vector2 (4.2f, -11.9f)); // add Mass?
		MassList.Add (new Vector2 (-5.3f, 14.5f));
		MassList.Add (new Vector2 (26.1f, 0.6f));

	}

	Vector2 DetectForceObject (){
		foreach (Vector2 index in MassList){
			if ((index - rg2d.position).magnitude <= 5) { // find a force master
				if (needAntiV) {
					rg2d.AddForce (-rg2d.velocity, ForceMode2D.Impulse);
					Vector2 initCircling = new Vector2 (-(rg2d.position-index).y,(rg2d.position-index).x );
					rg2d.AddForce (initCircling, ForceMode2D.Impulse);
					needAntiV = false;

				}

				MassCenter = index;
				speed = 1; // set to Mass?
				return index - rg2d.position;
			}
		}

		needAntiV = true;
		return new Vector2(0,0); // no force master, no force
	}

	void DetectInput(){
		if (Input.GetKey ("l")) {
			rg2d.AddForce (rg2d.velocity*0.2f, ForceMode2D.Impulse);
		}

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

		if(Input.GetKeyDown ("right"))
		{
			Vector3 target = planet.transform.position;
			float s = 10;
			target.z = transform.position.z;
			transform.position = Vector3.MoveTowards(transform.position, target, s * Time.deltaTime);

			//planet.position.x

			//rg2d.AddForce(perpendicular * speed);
		}

		if(Input.GetKeyDown ("left"))
		{
			Vector3 target = planet.transform.position;
			float s = 10;
			target.z = transform.position.z;
			transform.position = Vector3.MoveTowards(transform.position, target, -s * Time.deltaTime);

			//planet.position.x

			//rg2d.AddForce(perpendicular * speed);
		}
	}


}
