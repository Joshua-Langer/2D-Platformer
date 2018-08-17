using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageRemoval : MonoBehaviour {

    //public vars

    //private vars
    PlayerMan playerMan;
    
    // Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerMan = other.GetComponent<PlayerMan>();
            playerMan.ZeroHealth();
            if (Grid.gameManagerProper.playerLives == 0)
            {
                playerMan.KillPlayer();
            }
        }
        else
            Destroy(other.gameObject);
    }
}
