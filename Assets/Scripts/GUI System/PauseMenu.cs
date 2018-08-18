using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    //private vars
    GameObject[] pauseObjects;
    Scene activeScene;
    GameObject[] keybindObjects;
    bool keyBindActive;
    bool pauseActive;

	void Awake()
    {
        GameManagerProper game = Object.FindObjectOfType<GameManagerProper>();
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        keybindObjects = GameObject.FindGameObjectsWithTag("ShowOnKeyBind");
        keyBindActive = false;
        pauseActive = false;
        HideKeyBindMenu();
        HidePaused();
    }

    void Update()
    {
        KeyBind();
    }

    public void Restart()
    {
        activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }

    public void PauseControl()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowPaused();
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            HidePaused();
        }
    }

    void KeyBind()
    {
        if(Input.GetKey(Grid.gameManagerProper.pause))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseActive = true;
                ShowPaused();
            }
            else if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseActive = false;
                HidePaused();
            }
        }
        if(keyBindActive && Input.GetKey(Grid.gameManagerProper.pause))
        {
            ShowPaused();
        }
        
    }

    public void ShowPaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    public void HidePaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void KeyBindMenu()
    {
        HidePaused();
        pauseActive = false;
        keyBindActive = true;
        foreach(GameObject g in keybindObjects)
        {
            g.SetActive(true);
        }
    }

    public void HideKeyBindMenu()
    {
        foreach(GameObject g in keybindObjects)
        {
            g.SetActive(false);
        }
        keyBindActive = false;
        if (pauseActive)
            ShowPaused();
        else
            return;
    }
 
}
