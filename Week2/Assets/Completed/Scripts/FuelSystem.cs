using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FuelSystem : MonoBehaviour {
    public float FuelMeter = 100;
    public float burn = 25;
    public float refuel = 10;
    private float maxMeter;

    public float timeOrbit;

    private Image bar;
    private Rigidbody2D rg2d;
    private PlayerSM gameState;

    // Use this for initialization
    void Start () {
        // finds the player and gets rigidbody 2d
        maxMeter = transform.localScale.x;
        rg2d = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        gameState = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSM>();
        bar = GetComponent<Image>();

        timeOrbit = 0;
    }

    // Update is called once per frame
    void Update () {

        if (gameState.currentState == PlayerSM.PlayerState.LAUNCH)
        {
            // set time of orbit to zero
            timeOrbit = 0;

            // Burns fuel
            float burnedAmount = Time.deltaTime * burn;

            if (burnedAmount > FuelMeter)
                FuelMeter = 0;
            else FuelMeter -= Time.deltaTime * burn;

            if (FuelMeter == 0) // fuel is empty
                rg2d.drag = 2; // Rocket slows down
            else
                rg2d.drag = 0; // rocket keeps going

        }
        else if (gameState.currentState == PlayerSM.PlayerState.ORBIT)
        {
            // add time orbit
            timeOrbit += Time.deltaTime;

            // refuel while orbitting
            float refuelAmount = Time.deltaTime * refuel;

            if (refuelAmount + FuelMeter > 100)
                FuelMeter = 100;
            else FuelMeter += Time.deltaTime * refuel;
        }

        if (timeOrbit > 5) {
            gameState.currentState = PlayerSM.PlayerState.GAMEOVER;
            rg2d.velocity = new Vector2(0, 0);
        }

        float percent = FuelMeter / 100.0f;
        bar.fillAmount = percent;
    }
}
