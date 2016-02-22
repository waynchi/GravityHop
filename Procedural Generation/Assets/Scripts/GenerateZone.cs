using UnityEngine;
using System.Collections;

public class GenerateZone : MonoBehaviour
{
	public Transform background;
	public Transform planet;
	private Rigidbody2D rigidBody;

	private int zone = 0;

	// Use this for initialization
	void Start ()
	{
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (rigidBody.position.y / 30 > zone) {
			zone++;
			Instantiate(background, new Vector3(0, 30*zone, 0), Quaternion.identity);
			//Generate all of the planets in a zone.
			int numPlanets = (int) (Random.value *10 + 5);
			float planetZone = 30 / numPlanets;
			for (int i = 0; i < numPlanets; i++) {
				float scale = Random.value * 2;
				Vector3 v = planet.localScale;
				v.x *= scale;
				v.y *= scale;
				planet.localScale = v;
				Instantiate (planet, new Vector3 (Random.value * 10 - 5, (zone *30) + ( i * ((Random.value +1)*planetZone)) , 0), Quaternion.identity);
				Vector3 v2 = planet.localScale;
				v2.x = 1;
				v2.y = 1;
				planet.localScale = v2;
			}
		}
	}
}

