using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    GameObject[] pauseObjects;
    Scene activeScene;

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
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;

                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                Time.timeScale = 1;
                hidePaused();
            }
        }
	}

    public void Restart()
    {
        activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
        Debug.Log("Restart Pressed");
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
        Debug.Log("Main Menu Loaded");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

}
