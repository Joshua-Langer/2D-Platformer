using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

    //public vars
    public float playerMaxHealth;
    //public int playerLives;
    public float currentHealth;

    //private vars

    bool isInvulnerable;
    playerAudio playerSounds;
    GameManager GM;
    PlayerManager PM;
    UIManager UIMan;

        
	// Use this for initialization
	void Start ()
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        PM = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        UIMan = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
        currentHealth = playerMaxHealth;
        isInvulnerable = false;
        playerSounds = GetComponent<playerAudio>();
        
        //playerLives = 3;
    }

    void Update()
    {
        if(UIMan == null)
        {
            UIMan = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
        }
        //UIMan.health.text = currentHealth.ToString();
       // Debug.Log(UIMan);
    }
	
    public void takeDamage(float damage)
    {
        if (!isInvulnerable)
        {
            if (damage <= 0)
                return;

            currentHealth -= damage;
            Debug.Log(currentHealth);


            if (currentHealth <= 0)
            {
                playerSounds.StartCoroutine("DeathAudio");
                PM.DisablePlayer();
                killPlayer();
            }
        }
    }

    public void returnHealth(float regen)
    {
        if (regen <= 0)
            return;
        currentHealth += regen;
        Debug.Log(currentHealth);


        if (currentHealth >= playerMaxHealth)
        {
            currentHealth = playerMaxHealth;
            Debug.Log(currentHealth);
        }

    }

    public void Invulnerable(float time)
    {
        isInvulnerable = true;

        CancelInvoke("takeDamage");
        Invoke("SetDamage", time);
    }

    public void SetDamage()
    {
        isInvulnerable = false;
    }

    public void killPlayer()
    {
        gameObject.SetActive(false);
    }

    //Clear the health to 0 if falls through Garbage Removal
    public void ZeroHealth()
    {
        currentHealth = 0;
        UIMan.PlayerHealthHUDDamage();
        Debug.Log(currentHealth);
    }

    //Attached Call to GM
    public void Exit()
    {
        GM.NextLevel();
       // DontDestroyOnLoad(this);
    }
}
