using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invulnerableGem : MonoBehaviour {

    //public vars
    public float health;
    public float time;

    //private vars
    PlayerMan playerMan;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerMan = other.gameObject.GetComponent<PlayerMan>();
            playerMan.Invulnerable(time);
            playerMan.ReturnHealth(health);
            Destroy(gameObject);
        }
    }
}
