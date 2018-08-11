using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPowerup : MonoBehaviour
{
    //purpose to generate a health pickup to regenerate health

    //public vars
    public float health;

    //private vars
    playerHealth PHP;
    
    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PHP = other.gameObject.GetComponent<playerHealth>();
            PHP.returnHealth(health);
            Destroy(gameObject);
        }
    }
}
