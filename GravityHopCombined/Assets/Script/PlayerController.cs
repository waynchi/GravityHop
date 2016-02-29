using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	public float speed=1;
	public float NewTonPara;
	public bool needAntiV = true;
	public ArrayList MassList = new ArrayList();
	public Vector2 MassCenter;
	private Rigidbody2D rg2d;


	void Start()
	{
		rg2d = GetComponent<Rigidbody2D> ();
		rg2d.mass = 2;
		rg2d.AddForce (-2*rg2d.position, ForceMode2D.Impulse);
		rg2d.freezeRotation = true;
	}

	void Update()
	{
		DetectInput ();
	/*	Vector2 UniversalGravitation = DetectForceObject ();
		rg2d.AddForce (UniversalGravitation*speed);

	*/

	}


	void DetectInput (){
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Moved) {
				rg2d.AddForce (touch.deltaPosition*5, ForceMode2D.Force);
			}
		}
	}

}
