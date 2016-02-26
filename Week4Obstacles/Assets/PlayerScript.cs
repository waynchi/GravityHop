using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public GameObject[] planets;
    public Rigidbody2D rb2d;
    public Vector3 axis = new Vector3(0, 0, 1);
    public Vector3 center;
    public int dir = 1;
    public enum State
    {
        ROTATING, LAUNCHING
    };
    public State state;

    // Use this for initialization
    void Start()
    {
        state = State.ROTATING; // set to rotating
        planets = GameObject.FindGameObjectsWithTag("Planet");
        rb2d = GetComponent<Rigidbody2D>();

        // Spawns the player at the leftmost planet
        int first = 0;

        // Sets the visible gravity boundary
        for (int i = 0; i < planets.Length; ++i)
        {
            planets[i].transform.localScale = new Vector3(6, 6, 0);
        }

        for (int i = 1; i < planets.Length; i++) // finds the leftmost planet
        {
            if (planets[i].transform.position.x < planets[first].transform.position.x)
                first = i;
        }

        // change position of player
        center = planets[first].transform.position;
        transform.position = center - new Vector3(3, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        bool upButton = Input.GetKeyDown(KeyCode.UpArrow);
        bool downButton = Input.GetKeyDown(KeyCode.DownArrow);

        // Rotates around a planet's center
        switch (state){
            case State.ROTATING:
                transform.RotateAround(center, axis, Time.deltaTime * 80 * dir);

                if (upButton)
                { // Changes direction of the rotation
                    dir *= -1;
                }
                else if (downButton)
                { // Launches the player based from rotation
                  // Uses Left Hand Rule to find direction the planet will be launched
                    rb2d.velocity = Vector3.Cross(axis, transform.position - center).normalized * dir * 3;
                    state = State.LAUNCHING;
                }
                break;
            case State.LAUNCHING:
                Vector3 diff;
                for (int i = 0; i < planets.Length; i++) // tries to see if there's a planet that catches the player
                {
                    if (center != planets[i].transform.position) { // if the planet is not where the player was before
                        diff = planets[i].transform.position - transform.position;
                        float len = diff.magnitude;
                        if (len <= 3) { // finds if player is within orbital pull
                            center = planets[i].transform.position;
                            state = State.ROTATING;

                            // determines direction of orbit
                            Vector3 cross = Vector3.Cross(axis, transform.position - center);
                            if (Vector3.Dot(rb2d.velocity, cross) >= 0)
                                dir = 1;
                            else dir = -1;

                            rb2d.velocity = new Vector3(0, 0, 0);
                        }
                    }
                }
                break;
            default: break;
        }
    }
}
