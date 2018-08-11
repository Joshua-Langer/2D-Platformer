using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {

    //public vars
    public float damage;
    public float damageRate;
    public float knockBack;

    //private vars
    float nextDamage;
    playerHealth PlayerHealth;
    
    
    // Use this for initialization
	void Start ()
    {
        nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    //Damage Player
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && nextDamage<Time.time)
        {
            PlayerHealth = other.gameObject.GetComponent<playerHealth>();
            PlayerHealth.takeDamage(damage);
            nextDamage = Time.time + damageRate;
            KnockBack(other.transform);
        }

    }
    //Player Knockback from damage
    void KnockBack(Transform obj)
    {
        Vector2 knockDir = new Vector2(0, (obj.position.y - transform.position.y)).normalized;
        knockDir *= knockBack;
        Rigidbody2D knockRB = obj.gameObject.GetComponent<Rigidbody2D>();
        knockRB.velocity = Vector2.zero;
        knockRB.AddForce(knockDir, ForceMode2D.Impulse); 
    }
}
