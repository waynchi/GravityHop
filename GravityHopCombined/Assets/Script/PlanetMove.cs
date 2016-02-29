using UnityEngine;
using System.Collections;

public class PlanetMove : MonoBehaviour {


	private Rigidbody2D rb2d;

	private float timeLeft;
	public int dir;

	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		dir = 1;
	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		if(timeLeft < 0)
		{
			rb2d.velocity = new Vector2(4 * dir, 0);
			dir *= -1;

			timeLeft = 1;
		}

	}
}
