using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

    BoxCollider2D bc2d;
    SpriteRenderer sr;
    public float timeOnOff = 1;
    float timeLeft;

	// Use this for initialization
	void Start () {
        bc2d = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        timeLeft = timeOnOff;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0) // turns on/off the object
        {
            timeLeft = timeOnOff;
            bc2d.enabled = !bc2d.enabled;
            sr.enabled = !sr.enabled;
        }
	}
}
