using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //vars
    [SerializeField]
    Text versionText;
    string gameText;
    

    //Main Menu scene control system

    void Start()
    {
        gameText = Application.version;
        
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1); //temp, will eventually load a scene that generates the level map. Currently loads the test level.
        Debug.Log("Loading temp scene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit the Game");
    }
	
}
