using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileDamage : MonoBehaviour {

    //public vars
    public float damage;
    public GameObject explosionEffect;

    //private vars
    projectileController PC;
    enemyHealth hurtEnemy;

    void Awake()
    {
        PC = GetComponent<projectileController>();
    }

    public void IncreaseDamage(float inc)
    {
        damage += inc;
    }

    public void DecreaseDamage(float inc)
    {
        damage -= inc;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            PC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "Enemy")
            {
                hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.takeDamage(damage);

            }
            
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            PC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.takeDamage(damage);

            }
        }
    }



}
