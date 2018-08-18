using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StopWatchManager : MonoBehaviour
{
    //Private Vars
    [SerializeField]
    Text text;
    public float theTime;
    bool playing;
    public TimeSpan time;

    //public vars
    public float speed = 1;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(playing)
        {
            theTime += Time.deltaTime * speed;
            string hours = Mathf.Floor((theTime % 216000) / 3600).ToString("00");
            string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
            string seconds = (theTime % 60).ToString("00");
            //Place Miliseconds here
            text.text = hours + ":" + minutes + ":" + seconds;
            TimeFormat();
        }
	}

    public void Playing()
    {
        playing = true;
    }

    public void NotPlaying()
    {
        playing = false;
    }

    public void ClearTime()
    {
        theTime = 0;
        text.text = "00:00:00.0";
    }

    public void TimeFormat()
    {
        time = TimeSpan.FromSeconds(theTime);
        Debug.Log(time.ToString());
    }
}
