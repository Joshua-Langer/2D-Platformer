using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2D : MonoBehaviour {

    //public vars
    public Transform target; //what is being followed
    public float smoothing; //keep it from being jagged


    //private vars
    Vector3 offset;
    float lowY;

	// Use this for initialization
	void Start ()
    {
        offset = transform.position - target.position;
        lowY = transform.position.y;
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void FixedUpdate ()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        if(transform.position.y < lowY) //if lowY happens stop at lowY
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);  
        }
	}
}
