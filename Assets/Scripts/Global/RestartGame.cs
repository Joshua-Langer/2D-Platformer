using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartGame : MonoBehaviour {

    //public vars
    public float restartTime;

    //private vars
    bool restartNow = false;
    float restartTimeActual;
    Scene activeScene;

	
	// Update is called once per frame
	void Update ()
    {
		if(restartNow && restartTimeActual <= Time.time)
        {
            //Debug.Log("Game will restart in " + restartTimeActual);
            activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
            
        }
        else if(restartNow && Input.GetKey(KeyCode.R))
        {
            activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
           // Debug.Log("Restart Pressed");
        }
    }

    public void Restart()
    {
        restartNow = true;
        restartTimeActual = Time.time + restartTime;

        
    }
}
