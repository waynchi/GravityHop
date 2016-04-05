using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {

    public float sec = 30;
    Text time;
    bool stopTimer;

    //central state machine
    public CentralStateScript stateMachine;

    void Start () {
        time = GetComponent<Text>();
        stopTimer = false;
        if (stateMachine == null)
            stateMachine = GameObject.FindGameObjectWithTag("SM").GetComponent<CentralStateScript>();
    }

    // Update is called once per frame
    void Update () {
        if (stateMachine.getGameState() != CentralStateScript.GameState.Victory)
        {
            sec -= Time.deltaTime;
            if (sec <= 0)
            {
                sec = 0;
                stateMachine.GameOver();
            }
            string min = ((int)sec / 60).ToString();
            time.text = min + ":" + sec.ToString(".") + sec.ToString(".00");
        }
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
