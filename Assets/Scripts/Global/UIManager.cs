using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //This Script is used to manage all UI Behaviors and allow the GM to activate them when needed.
    
    GameObject[] pauseObjects;
    Scene activeScene;

    [SerializeField]
    Text gameOverText;
    public int WaitingTime;
    public Slider playerHUD;
    playerHealth playerHP;
    public Text health;

    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
        

	}
	
	// Update is called once per frame
	void Update ()
    {
        KeyBind();

        if(playerHP == null)
            playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
    }

    public void Restart()
    {
        activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
       // Debug.Log("Restart Pressed");
    }

    public void PauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    void KeyBind()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;

                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                //Debug.Log("high");
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }

    public void showPaused()
    {
        foreach(GameObject g in pauseObjects)
        {
           // Debug.Log("Game is Paused");
            g.SetActive(true);
        }
    }

    public void hidePaused()
    {
        foreach(GameObject g in pauseObjects)
        {
           // Debug.Log("Game is not Paused");
            g.SetActive(false);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
       // Debug.Log("Main Menu Loaded");
    }

    public void Exit()
    {
        Application.Quit();
        //Debug.Log("Game is exiting");
    }

    public IEnumerator GameOverScreen()
    {
        //Call animator for Game Over
        Animator gameOverAnim = gameOverText.GetComponent<Animator>();
        gameOverAnim.SetBool("isGameOver", true);
        yield return new WaitForSeconds(4f);
        gameOverAnim.SetBool("isGameOver", false);
    }

    public void PlayerHealthHUDDamage()
    {
        playerHUD.value = playerHP.currentHealth;
    }

    public void PlayerHealthHUDRegen()
    {
        playerHUD.value = playerHP.currentHealth;
    }
}
