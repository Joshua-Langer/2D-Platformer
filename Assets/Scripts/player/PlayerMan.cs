using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMan : MonoBehaviour {

    //public vars
    public bool playerDead;
    public float playerMaxHealth;
    public float currentHealth;
    //TODO: Implement Lives
    public int playerLives; //NYI

    //private vars
    bool isInvulnerable;

    


    void Awake()
    {
        GameManagerProper game = Object.FindObjectOfType<GameManagerProper>();
        GameSFX sfx = Object.FindObjectOfType<GameSFX>();
        //UIManager here?

        currentHealth = playerMaxHealth;
        isInvulnerable = false;
        playerDead = false;
    }

    public void TakeDamage(float damage)
    {
        if (!isInvulnerable)
        {
            if (damage <= 0)
                return;

            currentHealth -= damage;
            Debug.Log(currentHealth);


            if (currentHealth <= 0)
            {
                Grid.gameSFX.StartCoroutine("DeathAudio");
                playerDead = true;
                KillPlayer();
                Grid.gameManagerProper.LoseGame();
            }
        }
    }

    public void ReturnHealth(float regen)
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

    public void KillPlayer()
    {
        Destroy(gameObject);
    }

    //Clear the health to 0 if falls through Garbage Removal
    public void ZeroHealth()
    {
        currentHealth = 0;
        Grid.gameManagerProper.LoseGame();
        KillPlayer();
        Debug.Log(currentHealth);
    }

    //Attached Call to GM
    public void Exit()
    {
        Grid.gameManagerProper.NextLevel();
        // DontDestroyOnLoad(this);
    }
}

