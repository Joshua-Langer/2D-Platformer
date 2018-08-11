using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {

    //public vars
    public float enemyMaxHealth;

    //private vars
    float currentHealth;

    //HUD Vars
    public Slider enemyHealthHUD;

    // Use this for initialization
    void Start()
    {
        currentHealth = enemyMaxHealth;
        enemyHealthHUD.maxValue = enemyMaxHealth;
        enemyHealthHUD.value = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(float health)
    {
        enemyHealthHUD.gameObject.SetActive(true);
        currentHealth -= health;
        enemyHealthHUD.value = currentHealth;
        if (currentHealth <= 0)
        {
            KillObject();
        }
    }

    public void returnHealth(float health)
    {
        //TODO: build regen for enemies
    }

    public void KillObject()
    {
        Destroy(gameObject);
    }   
}
