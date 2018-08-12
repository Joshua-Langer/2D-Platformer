using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

    //public vars
    public float playerMaxHealth;
    public RestartGame restartGame;
    //public int playerLives;
    public float currentHealth;

    //private vars

    bool isInvulnerable;
    playerAudio playerSounds;
    GameManager GM;

    //HUD Vars
    public Slider healthHUD;
    [SerializeField]
    Text gameOverText;
    [SerializeField]
    Text winText;
        
	// Use this for initialization
	void Start ()
    {
        currentHealth = playerMaxHealth;
        healthHUD.maxValue = playerMaxHealth;
        healthHUD.value = playerMaxHealth;
        isInvulnerable = false;
        playerSounds = GetComponent<playerAudio>();
        GM = new GameManager();
        //playerLives = 3;

    }
	
    public void takeDamage(float damage)
    {
        if (!isInvulnerable)
        {
            if (damage <= 0)
                return;

            currentHealth -= damage;
            healthHUD.value = currentHealth;

            if (currentHealth <= 0)
            {
                playerSounds.StartCoroutine("DeathAudio");
                killPlayer();
            }
        }
    }

    public void returnHealth(float regen)
    {
        if (regen <= 0)
            return;
        currentHealth += regen;
        healthHUD.value = currentHealth;

        if (currentHealth >= playerMaxHealth)
            currentHealth = playerMaxHealth;

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
       //Delete this function.
    }

    //Clear the health to 0 if falls through Garbage Removal
    public void ZeroHealth()
    {
        currentHealth = 0;
       // Debug.Log(currentHealth);
    }

    //Attached Call to GM
    public void Exit()
    {
        GM.NextLevel();
    }
}
