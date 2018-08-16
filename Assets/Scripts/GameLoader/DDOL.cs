﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("DDOL " + gameObject.name);
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
    }

}
