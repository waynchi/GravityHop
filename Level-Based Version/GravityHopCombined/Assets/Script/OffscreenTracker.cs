using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OffscreenTracker : MonoBehaviour {

    GameObject player;
    GameObject[] planets;
    GameObject[] bubbles;
    Image bubble1;
    Image bubble2;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        planets = GameObject.FindGameObjectsWithTag("Planet"); // grabs all the planets in game
        bubbles = GameObject.FindGameObjectsWithTag("Bubble");
        bubble1 = bubbles[0].GetComponent<Image>();
        bubble2 = bubbles[1].GetComponent<Image>();
        Debug.Log(bubbles.Length);
    }

    // Update is called once per frame
    void Update () {

        float x;
        float y;
        int num = 0;

        float shortest = 1000;
        float shortest2;
        int shortest_index = -1;
        int shortest_index2 = -1;
        Vector3 diff;
        for (int i = 0; i < planets.Length; ++i) // checks the planets
        {
            diff = player.transform.position - planets[i].transform.position;
            x = Mathf.Abs(diff.x);
            y = Mathf.Abs(diff.y);
            if (!(y < 5 && x < 13)) // detects whether the planet is offscreen
            {
                if (shortest > diff.magnitude)
                {
                    shortest2 = shortest;
                    shortest_index2 = shortest_index;
                    shortest = diff.magnitude;
                    shortest_index = i;
                }
                ++num;
            }
        }


        // gets the direction of the player
        Vector2 dir = planets[shortest_index].transform.position - player.transform.position;
        Vector2 dir2 = planets[shortest_index2].transform.position - player.transform.position;

        dir.Normalize();
        dir2.Normalize();

        // Place two indicators for the nearest planets
        bubble1.rectTransform.anchoredPosition = dir * 400;
        bubble2.rectTransform.anchoredPosition = dir2 * 400;

    }
}
