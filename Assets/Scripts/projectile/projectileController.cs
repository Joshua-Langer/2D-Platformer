using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

    //public vars
    public float fireSpeed;

    //private vars
    Rigidbody2D rb;
    
    
    // Used during instatiante of object
	void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();

        if(transform.localRotation.z>0)
            rb.AddForce(new Vector2(-1, 0) * fireSpeed, ForceMode2D.Impulse);
        else
            rb.AddForce(new Vector2(1, 0)* fireSpeed, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void removeForce()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
