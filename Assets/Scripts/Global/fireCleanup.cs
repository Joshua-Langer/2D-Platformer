using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireCleanup : MonoBehaviour {

    //public vars

    public float aliveTime;

    //private vars

	
	void Awake ()
    {
        Destroy(gameObject, aliveTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
