using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSFX : MonoBehaviour {

    [Header("Game SFX")]
    [SerializeField]
    AudioClip death;
    [SerializeField]
    AudioClip jump;

    [Header("Audio Source")]
    AudioSource sounds;

    public IEnumerator JumpAudio()
    {
        sounds = GetComponent<AudioSource>();
        yield return new WaitForSeconds(0);
        sounds.clip = jump;
        sounds.Play();
    }

    public IEnumerator DeathAudio()
    {
        sounds = GetComponent<AudioSource>();
        yield return new WaitForSeconds(0.5f);
        sounds.clip = death;
        sounds.volume = 1;
        sounds.Play();
    }
}
