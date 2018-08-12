using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageRemoval : MonoBehaviour {

    //public vars

    //private vars
    playerHealth PH;
    
    // Use this for initialization
	void Start () {
		
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
            //PH.killPlayer();
        }
        else
            Destroy(other.gameObject);
    }
}
