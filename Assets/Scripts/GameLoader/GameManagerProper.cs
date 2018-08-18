using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManagerProper : MonoBehaviour {

    //public vars
    public float highestTime;
    public float lastTime;
    public int playerLives;
    TimeSpan timeSaved;

    //private vars
    int activeScene;
    int previousScene;
    float restartTimer;
    float playerHealth;
    string playerName;
    PlayerHUD hud;
    PlayerMan player;
    StopWatchManager stopWatch;
    TimeSaveController timeSubmit;

    //Custom Input Map
    public KeyCode jump { get; set; }
    public KeyCode attack { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    public KeyCode setIce { get; set; }
    public KeyCode setFire { get; set; }
    public KeyCode setArcane { get; set; }
    public KeyCode pause { get; set; }

    
    // Use this for initialization
	void Awake ()
    {
        playerLives = 3;
        Time.timeScale = 1;
        restartTimer = Time.time + 5.5f;
        hud = GameObject.FindObjectOfType<PlayerHUD>();
        player = GameObject.FindObjectOfType<PlayerMan>();
        stopWatch = GameObject.FindObjectOfType<StopWatchManager>();
        timeSubmit = GameObject.FindObjectOfType<TimeSaveController>();
        if (playerName == null)
            playerName = "tester";
        //Debug.Log("Game Manager Loaded");

        //InputMap
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
        attack = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("attackKey", "F"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        setIce = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("iceKey", "Alpha3"));
        setFire = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("fireKey", "Alpha2"));
        setArcane = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("arcaneKey", "Alpha1"));
        pause = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pauseKey", "Escape"));
    }
    void Update()
    {
        if (hud == null)
        {
            hud = GameObject.FindObjectOfType<PlayerHUD>();
            Debug.Log(hud);
        }
        if (player == null)
        {
            player = GameObject.FindObjectOfType<PlayerMan>();
        }
        if(timeSubmit == null)
        {
            timeSubmit = GameObject.FindObjectOfType<TimeSaveController>();
        }
        timeSaved = stopWatch.time;
        //Debug.Log(timeSaved);
    }
    void WinGame()
    {
        if (SceneManager.GetActiveScene().buildIndex < 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            StartCoroutine(timeSubmit.PostScores( playerName, timeSaved));
            SceneManager.LoadScene(1);
            stopWatch.NotPlaying();
        }
    }

    public void NextLevel()
    {
        WinGame();
    }
    
     IEnumerator Restart(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
        playerLives = 3;
    }

    public void LoseGame()
    {
        stopWatch.NotPlaying();
        //Debug.Log("Game Over");
        hud.StartCoroutine("GameOverScreen");
        StartCoroutine("Restart", restartTimer);        
    }

    void SubmitHighLevel(float time)
    {
        if(time > highestTime)
        {
            highestTime = time;
            Save();
        }
    }

    public float GetHighLevel()
    {
        return highestTime;
    }

    void Save()
    {
        PlayerPrefs.SetFloat("highestLevel", highestTime);
        Debug.Log(highestTime);
    }

    public void Load()
    {
        PlayerPrefs.GetFloat("highestTime");
        Debug.Log(PlayerPrefs.GetFloat("highestTime"));
    }

    public void LoseLife()
    {
        //Hud reflect change
        hud.Lives();
        //Restart the level
        ResetLevel();
    }

    void ResetLevel()
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeScene);
    }

    public void PlayerHealthLoss()
    {
        playerHealth = player.currentHealth;
        hud.playerHealth.value = playerHealth;
    }

    public void PlayerHealthGain()
    {
        playerHealth = player.currentHealth;
        hud.playerHealth.value = playerHealth;
    }
}
