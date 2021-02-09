using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountDown : MonoBehaviour
{
    public GameObject textDisplay;
    private int _secondsLeft = 30;
    private IEnumerator timerTake;
    public int SecondsLeft {
        get
        {
            return this._secondsLeft;
        }
        set
        {
            this._secondsLeft = value;
        } 
    }
    public bool takingAway = false;
    //public Game game;

    /*public TimeCountDown()
    {
        SecondsLeft = 30;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        textDisplay.GetComponent<Text>().text = "00:" + SecondsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && SecondsLeft > 0)
        {
            timerTake = TimerTake();
            StartCoroutine(timerTake);
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        SecondsLeft -= 1;
        if(SecondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + SecondsLeft;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:" + SecondsLeft;
        }
        takingAway = false;
    }

    public void StopTime()
    {
        StopCoroutine(timerTake);
        Debug.Log("Stop Time Countdown");
    }

    public void Reset()
    {
        SecondsLeft = 30; 
    }
}
