using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    //public vars
    public int waitingTime;
    public Slider playerHealth;
    [HideInInspector]
    public int playerLives;

    //private serialized vars
    [SerializeField]
    Text gameOverText;
    [SerializeField]
    Text playerLivesText;

    //Private Vars
    PlayerMan player;
    float health;

    void Awake()
    {
        GameManagerProper game = Object.FindObjectOfType<GameManagerProper>();
        player = Object.FindObjectOfType<PlayerMan>();
        Lives();
    }

    void Update()
    {
        health = player.currentHealth;
        playerHealth.value = health;
    }

    public IEnumerator GameOverScreen()
    {
        Animator gameOverAnim = gameOverText.GetComponent<Animator>();
        gameOverAnim.SetBool("isGameOver", true);
        yield return new WaitForSeconds(4f);
        gameOverAnim.SetBool("isGameOver", false);
    }

    public void Lives()
    {
        playerLives = Grid.gameManagerProper.playerLives;
        playerLivesText.text = playerLives.ToString();
        Debug.Log(playerLives);
    }

    //Still bugged will decrease value on ZeroHealth Call.
    public void Health()
    {
        health = player.currentHealth;
       // Debug.Log(health);
        //Debug.Log("Called Health HUD Function");  //Function is being called according to this piece happening each damage tick
        playerHealth.value = health;
        Debug.Log(playerHealth.value);
    }
}
