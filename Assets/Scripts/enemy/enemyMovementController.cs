using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour
{

    //purpose of script is to have the enemy move toward the player without adding a collider. 
    //It will detect the tag within a certain range and once the player is in range it will move toward the player.


    //public vars
    public float enemySpeed;
    public GameObject enemyGraphic; //for facing

    //private vars
    Animator anim;

    
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
