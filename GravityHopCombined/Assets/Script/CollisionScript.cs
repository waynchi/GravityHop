using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {

	public Canvas HUDCanvas;
	public Canvas ScoreCanvas;
	Animator anim;
	ScoreSystem scoreScript;
    ScoreSystem ss;
    bool invincibility;
    private Rigidbody2D rb2d;

	public float restartDelay;

	private float restartCount;
    
    // Use this for initialization
    void Start () {
        ss = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreSystem>();
        rb2d = GetComponent<Rigidbody2D>();
        invincibility = false;
		anim = HUDCanvas.GetComponent<Animator> ();
		scoreScript = ScoreCanvas.GetComponentInChildren<ScoreSystem> ();
		restartDelay = 5f;
		restartCount = 0;
    }

    void OnCollisionEnter2D(Collision2D col) {
        string name = col.gameObject.name;
        if (name.Contains("Asteroid")) // An object that stays in place
        {
            if (invincibility) // if invincible, destroys the meteor
            {
                Destroy(col.collider.gameObject);
                invincibility = false;
            }
            else {
                // Finds the angle of collision
                Vector2 t = transform.position;
                Vector3 ortho = col.contacts[0].point - t;
                float angle = Vector3.Angle(ortho, rb2d.velocity);

                // if the ship takes a direct hit
				if (angle <= 30) {
					Destroy (gameObject);
					GameOver ();
				}
            }
        }
        else if (name.Contains("Drone")) // Floating drone that will patrol back and forth
        {
			if (invincibility) {
				Destroy (col.collider.gameObject);
				invincibility = false;
			} else {
				Destroy (gameObject);
				GameOver (); 
			}
        }

        else if (name.Contains("Hole")) // Instant game over
        {
            Destroy(gameObject);
			GameOver ();
        }

        else if (name.Contains("Laser")) // Laser fields that can kill player: turns on and off
        {
			if (invincibility) {
				Destroy (col.collider.gameObject);
				invincibility = false;
			} else {
				Destroy (gameObject);
				GameOver ();
			}
        }

        else if (name.Contains("Wall")) // Circular wall that rotates around a point
        {
            Destroy(gameObject);
			GameOver ();
        }

        else if (name.Contains("Enemy")) // Enemy chases the player on the planet
        {
            Destroy(gameObject);
			GameOver ();
        }

        else if (name.Contains("CoinSprite")) // adds on to the score
        {
            ss.addScore(1000);
            Destroy(col.collider.gameObject);
        }

        else if (name.Contains("Star")) // adds on to score multiplier
        {
            ss.addMultiplier();
            Destroy(col.collider.gameObject);
        }

        else if (name.Contains("Invincibility")) // makes player impervious to drones, laser, and asteroids
        {
            invincibility = true;
            Destroy(col.collider.gameObject);
            // ship can pierce through obstacle
        }

        else if (name.Contains("Gravity")) // Increase the gravity field
        {
            Destroy(col.collider.gameObject);
            // Fetch the planets and increase the gravity field
        }

        else if (name.Contains("Homing")) // Allows player to tap and change direction to nearest planet
        {
            Destroy(col.collider.gameObject);
            // Find closest planet and home towards it
        }

    }

	void GameOver () {
		anim.SetTrigger ("GameOver");
		scoreScript.stop = true;
		HUDCanvas.GetComponentInChildren<UnityEngine.UI.Button> ().enabled = true;
	}

    // Update is called once per frame
    void Update () {
		if (scoreScript.stop == true) {
			if (restartCount >= restartDelay) {
				UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex); 
				restartCount = 0;
				scoreScript.stop = false;
			}
			restartCount += Time.deltaTime;
		}
	}
}
