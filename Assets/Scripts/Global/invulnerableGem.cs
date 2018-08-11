using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invulnerableGem : MonoBehaviour {

    //public vars
    public float health;
    public float time;

    //private vars
    playerHealth PHP;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PHP = other.gameObject.GetComponent<playerHealth>();
            PHP.Invulnerable(time);
            PHP.returnHealth(health);
            Destroy(gameObject);
        }
    }
}
