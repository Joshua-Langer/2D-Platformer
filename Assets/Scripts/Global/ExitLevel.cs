using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour {

    //private void
    PlayerMan playerMan;
   // GameManager GM;


	// Use this for initialization
	void Start ()
    {
        // GM = GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
     
	}

    //Old Remove once other works
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerMan = other.gameObject.GetComponent<PlayerMan>();
            playerMan.Exit();
        }
    }

}
