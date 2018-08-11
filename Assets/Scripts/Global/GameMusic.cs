using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameMusic : MonoBehaviour {

    [SerializeField]
    AudioClip levelMusic;
    [SerializeField]
    ulong LevelMusic;

    AudioSource gameMusic;
	// Use this for initialization
	void Start ()
    {
        gameMusic = GetComponent<AudioSource>();
	}
	
	void Awake ()
    {
        GameAudio();	
	}

    void GameAudio()
    {
        gameMusic.Play(LevelMusic);
    }
}
