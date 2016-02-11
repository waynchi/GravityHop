using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FuelSystem : MonoBehaviour {
    public float FuelMeter = 100;
    public float burn = 25;
    private float maxMeter;

    private Image bar;
    private Rigidbody2D rg2d;

    // Use this for initialization
    void Start () {
        // finds the player and gets rigidbody 2d
        maxMeter = transform.localScale.x;
        rg2d = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        bar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update () {
        
        float burnedAmount = Time.deltaTime * burn;

        if (burnedAmount > FuelMeter)
            FuelMeter = 0;
        else FuelMeter -= Time.deltaTime * burn;

        if (FuelMeter == 0) // fuel is empty
            rg2d.drag = 2; // Rocket slows down
        else
            rg2d.drag = 0; // rocket keeps going

        float percent = FuelMeter / 100.0f;
        bar.fillAmount = percent;

    }
}
