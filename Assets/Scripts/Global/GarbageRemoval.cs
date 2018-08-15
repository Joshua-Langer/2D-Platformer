using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageRemoval : MonoBehaviour {

    //public vars

    //private vars
    playerHealth PH;
    PlayerManager PM;
    
    // Use this for initialization
	void Start ()
    {
        PM = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PH = other.GetComponent<playerHealth>();
            PH.ZeroHealth();
            PH.killPlayer();
            PM.DisablePlayer();
        }
        else
            Destroy(other.gameObject);
    }
}
