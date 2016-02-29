using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

    public BoxCollider2D bc2d;
    public SpriteRenderer sr;
    float timeOnOff;
    float timeLeft;

	// Use this for initialization
	void Start () {
        bc2d = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        timeOnOff = 1;
        timeLeft = 1;
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
