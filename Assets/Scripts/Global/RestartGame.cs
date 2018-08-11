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

	
	// Update is called once per frame
	void Update ()
    {
		if(restartNow && restartTimeActual <= Time.time)
        {
            Debug.Log("Game will restart in " + restartTimeActual);
            SceneManager.LoadScene(0);
        }
        else if(restartNow && Input.GetKey(KeyCode.R))
        {
            restartTimeActual = 0;
            SceneManager.LoadScene(0);
        }
    }

    public void Restart()
    {
        restartNow = true;
        restartTimeActual = Time.time + restartTime;

        
    }
}
