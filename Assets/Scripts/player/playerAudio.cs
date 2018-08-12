using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class playerAudio : MonoBehaviour {

    [SerializeField]
    AudioClip death;
    [SerializeField]
    AudioClip jump;

    AudioSource sounds;

  
   



    public IEnumerator JumpAudio()
    {
        Debug.Log("Called JumpAudio from Player Controller");
        sounds = GetComponent<AudioSource>();
        yield return new WaitForSeconds(0);
        sounds.clip = jump;
        sounds.Play();
    }

    public IEnumerator DeathAudio()
    {
        Debug.Log("Called DeathAudio from PlayerHealth");
        sounds = GetComponent<AudioSource>();
        yield return new WaitForSeconds(0.5f);
        sounds.clip = death;
        sounds.volume = 1;
        sounds.Play();
    }
}
