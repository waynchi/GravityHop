using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {

    public float sec = 30;
    Text time;
    bool stopTimer;
	// Use this for initialization
	void Start () {
        time = GetComponent<Text>();
        stopTimer = false;
	}
	
	// Update is called once per frame
	void Update () {
        sec -= Time.deltaTime;
        string min = ((int)sec / 60).ToString();
        time.text = min + ":" + sec.ToString(".") + sec.ToString(".00");
	}

    public void stop()
    {
        stopTimer = true;
    }

    public void reset()
    {
        stopTimer = false;
    }

}
