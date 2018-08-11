using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

    //public vars
    public float playerMaxHealth;
    public RestartGame restartGame;

    //private vars
    float currentHealth;
    playerController PlayerController; //maybe redundant
    bool isInvulnerable;
    playerAudio playerSounds;

    //Scene nextScene;
   

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
        PlayerController = GetComponent<playerController>(); //still maybe redundant
        healthHUD.maxValue = playerMaxHealth;
        healthHUD.value = playerMaxHealth;
        isInvulnerable = false;
        playerSounds = GetComponent<playerAudio>();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
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
        playerSounds.DeathSound();
        Destroy(gameObject);
        //Call animator for Game Over
        Animator gameOverAnim = gameOverText.GetComponent<Animator>();
        gameOverAnim.SetTrigger("gameOver");
        restartGame.Restart();
        
    }

    //TODO: Move This
    public void WinGame()
    {
        Destroy(gameObject);
        //Animator winAnim = winText.GetComponent<Animator>();
        //winAnim.SetTrigger("gameOver");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
