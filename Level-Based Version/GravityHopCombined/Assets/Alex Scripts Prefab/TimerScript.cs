using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {

    public float timeLeft = 30;
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
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                stateMachine.GameOver();
            }

            if (timeLeft < 10)
            {
                time.text = "00" + ((int)timeLeft).ToString();
            }
            else {
                time.text = "0" + ((int)timeLeft).ToString();
            }
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

    public float getTime()
    {
        return timeLeft;
    }


}
