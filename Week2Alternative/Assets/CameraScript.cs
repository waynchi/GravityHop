using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    GameObject player;

    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position - new Vector3(0, 0, 10);
    }

    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position - new Vector3(0, 0, 10);
    }
}
