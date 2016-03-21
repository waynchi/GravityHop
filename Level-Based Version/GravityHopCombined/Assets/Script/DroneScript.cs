using UnityEngine;
using System.Collections;

public class DroneScript : MonoBehaviour {

    public enum PatrolState { STOP, MOVING }
    public PatrolState currentState;
    public Rigidbody2D rb2d;

    private float timeLeft;
    public int dir;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentState = PatrolState.STOP;
        dir = 1;
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;

        if(timeLeft < 0)
        {
            switch (currentState)
            {
                case PatrolState.STOP:
                    currentState = PatrolState.MOVING;
                    rb2d.velocity = new Vector2(4 * dir, 0);
                    dir *= -1;

                    timeLeft = 1;
                    break;

                case PatrolState.MOVING:
                    currentState = PatrolState.STOP;
                    rb2d.velocity = new Vector2(0, 0);

                    timeLeft = 1.5f;
                    break;
            }
        }

	}
}
