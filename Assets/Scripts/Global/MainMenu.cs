using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


    public class MainMenu : MonoBehaviour
    {
    //vars
    [HideInInspector]
    public bool StartGamePress;

    //private vars
    StopWatchManager stopWatch;

        //Main Menu scene control system

        void Start()
        {
        //VersionText();
        
        StartGamePress = false;
        }

    void Awake()
    {
        stopWatch = Object.FindObjectOfType<StopWatchManager>();
        stopWatch.ClearTime();
    }

    public void StartGame()
    {
        StartGamePress = true;
        SceneManager.LoadScene(2); //temp, will eventually load a scene that generates the level map. Currently loads the test level.
        stopWatch.Playing();
        //Debug.Log("Loading temp scene");
    }

        public void QuitGame()
        {
            Application.Quit();
           //Debug.Log("Quit the Game");
        }

        public void NewGameExtra()
        {
        Debug.Log("If player has beat all worlds and is save in JSON load the NG scenes");
          //Debug.Log("For NewGame +");
        }
    /*
        void VersionText()
        {
            //Debug.Log("Version Text Display");
            versionText.text =("Game Version " + VersionInformation.ToString() + " Pre-Alpha");
        }
*/

        public void LoadGame()
    {
        Debug.Log("Best Time Completed: " + PlayerPrefs.GetFloat("highestTime"));
    }
}

