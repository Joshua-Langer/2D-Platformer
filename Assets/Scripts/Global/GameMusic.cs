using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameMusic : MonoBehaviour {

    [SerializeField]
    AudioClip levelMusic;

    AudioSource gameMusic;
    
	void Awake ()
    {
        GameAudio();	
	}

    void GameAudio()
    {
        gameMusic = GetComponent<AudioSource>();
        gameMusic.clip = levelMusic;
        gameMusic.volume = .5f;
        gameMusic.loop = true;
        gameMusic.Play();
    }
}
