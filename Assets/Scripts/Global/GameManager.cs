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
    public int highestLevel = 0;

    //private vars
    PlayerManager playerManager;
    UIManager restartCommand;
    Scene activeScene;
    public int levelCompleted;
    UIManager userInterfaceCommand;
    float restartTimer;
    MainMenu menu;
    int previousScene;
    bool sceneChange;
    
    

    void Start()
    {
        levelCompleted = 0;
        DontDestroyOnLoad(gameObject);
        //userInterfaceCommand = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
        userInterfaceCommand = FindObjectOfType<UIManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<MainMenu>();
        restartTimer = Time.time + 5.5f;
        sceneChange = false;
        Debug.Log("Game Manager Loaded");
    }


    void Update()
    {
        if (!playerManager.isActiveAndEnabled)
            LoseGame();
        if (userInterfaceCommand == null && playerManager == null)
        {
            
            sceneChange = true;
            userInterfaceCommand = FindObjectOfType<UIManager>();
            playerManager = FindObjectOfType<PlayerManager>();
            
        }
        

    }

    public void WinGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log(highestLevel);
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Destroy(GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>());
            SceneManager.LoadScene(1);
            //Debug.Log(instance);
        }
    }

    public void LoseGame()
    {
        SubmitHighLevel(levelCompleted);
        userInterfaceCommand.StartCoroutine("GameOverScreen");
        Debug.Log("Game Can Restart");
        StartCoroutine("Restart", restartTimer);
       
    }

    public void NextLevel()
    {
        WinGame();
        levelCompleted++;
        Debug.Log(levelCompleted + " level is/are completed");
        DontDestroyOnLoad(this);
    }

    public IEnumerator Restart(int waitTime)
    {
        //Debug.Log("Called this when player died. Time to restart: " + waitTime);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);
        Destroy(this);
    }

    void SubmitHighLevel(int level)
    {
        if(level > highestLevel)
        {
            highestLevel = level;
            Save();
        }
    }

    public int GetHighLevel()
    {
        return highestLevel;
    }

    void Save()
    {
        PlayerPrefs.SetInt("highestLevel", highestLevel);
    }

    public void Load()
    {
        PlayerPrefs.GetInt("highestLevel");
    }
}
