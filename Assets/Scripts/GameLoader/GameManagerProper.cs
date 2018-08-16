using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerProper : MonoBehaviour {

    //public vars
    public int highestLevel = 0;
    public int levelCompleted = 0;

    //private vars
    Scene activeScene;
    float restartTimer;
    int previousScene;
    bool sceneChange;
    PlayerHUD hud;

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
        sceneChange = false;
        Time.timeScale = 1;
        restartTimer = Time.time + 5.5f;
        hud = Object.FindObjectOfType<PlayerHUD>();
        Debug.Log("Game Manager Loaded");

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
            hud = Object.FindObjectOfType<PlayerHUD>();
            Debug.Log(hud);
        }
    }
    void WinGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log(highestLevel);
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void NextLevel()
    {
        levelCompleted++;
        WinGame();
    }
    
     IEnumerator Restart(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }

    public void LoseGame()
    {
        SubmitHighLevel(levelCompleted);
        Debug.Log("Game Over");
        hud.StartCoroutine("GameOverScreen");
        StartCoroutine("Restart", restartTimer);
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
