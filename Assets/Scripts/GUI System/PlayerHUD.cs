using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    //public vars
    public int waitingTime;
    public Slider playerHealth;
    public int playerLives;

    //private serialized vars
    [SerializeField]
    Text gameOverText;

    //Private Vars
    PlayerMan player;

    void Awake()
    {
        GameManagerProper game = Object.FindObjectOfType<GameManagerProper>();
        player = Object.FindObjectOfType<PlayerMan>();
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
        Debug.Log(playerLives);
    }
}
