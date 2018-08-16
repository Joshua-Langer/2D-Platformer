using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    //public vars
    public int waitingTime;
    public Slider playerHealth;

    //private vars
    [SerializeField]
    Text gameOverText;

    void Awake()
    {
        GameManagerProper game = Object.FindObjectOfType<GameManagerProper>();
        PlayerMan player = Object.FindObjectOfType<PlayerMan>();
    }

    public IEnumerator GameOverScreen()
    {
        Animator gameOverAnim = gameOverText.GetComponent<Animator>();
        gameOverAnim.SetBool("isGameOver", true);
        yield return new WaitForSeconds(4f);
        gameOverAnim.SetBool("isGameOver", false);
    }
}
