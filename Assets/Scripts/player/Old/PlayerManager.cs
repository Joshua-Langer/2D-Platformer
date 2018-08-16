using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    //This script will control the other Player Scripts and funnel back to the Game Manager.

    //public vars

    //private vars
    playerHealth Health;
    GameManager gameManager;
    public bool playerDead;
    bool playerAttached;
    MainMenu menu;
    GameObject player;


    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<MainMenu>();
        playerDead = false;
        playerAttached = false;
        //Debug.Log("Player Manager loaded");
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            PlayerAttach();
            //Debug.Log(playerAttached);
            //Debug.Log(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void DisablePlayer()
    {
        gameObject.SetActive(false);
        playerDead = true;
       // Debug.Log("Player is disabled after death");
    }

    public void EnablePlayer()
    {
        gameObject.SetActive(true);
        playerDead = false;
    }

    //Regenerate the Player to this script.
    void PlayerAttach()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerAttached = true;
        }
    }    
}
