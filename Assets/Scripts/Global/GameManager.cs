using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Used to control all game conditions, win/lose etc.

    //public vars
    public static GameManager instance = null; //other other objects to access the game manager.

    //private vars
    [SerializeField]
    playerHealth Player;
    [SerializeField]
    UIManager restartCommand;
    [SerializeField]
    Text gameOverText;
    //meObject exitSign;
    Scene activeScene;
    [SerializeField]
    int WaitingTime;

    void Update()
    {
        LoseGame();
    }

    //TODO: Move This
    public void WinGame()
    {
        //Animator winAnim = winText.GetComponent<Animator>();
        //winAnim.SetTrigger("gameOver");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(0);
        }
    }

    //TODO: Move this to Game Conditions Script
    public void LoseGame()
    {
        if (Player.GetComponent<playerHealth>().currentHealth == 0)
        {
            //Call animator for Game Over
            Animator gameOverAnim = gameOverText.GetComponent<Animator>();
            gameOverAnim.SetTrigger("gameOver");
            StartCoroutine("Restart", WaitingTime);
        }
        DontDestroyOnLoad(this);
    }

    public void NextLevel()
    {
        WinGame();
        DontDestroyOnLoad(this);
    }

    IEnumerator Restart(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);
        DontDestroyOnLoad(this);
    }

}
