using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePowerup : MonoBehaviour
{
    //script purpose to increase damage dealt for a duration of time

    //public vars
    public float damageInc;
    public float timeDmg;

    //private vars
    projectileDamage  ProjDamage;
    playerController PlayerCont;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //increase the damage here then remove the object.
            ProjDamage = GetComponent<projectileDamage>();
            ProjDamage.damage += damageInc;
            Destroy(gameObject);
        }
    }


}
