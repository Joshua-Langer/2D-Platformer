using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class playerAudio : MonoBehaviour {

    [SerializeField]
    AudioClip death;
    [SerializeField]
    AudioClip jump;
    AudioSource audioSource;
  
   

	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
	}
	
	public void JumpSound()
    {
        audioSource.PlayOneShot(jump, 0.7f);
        //Debug.Log("Jump");
    }

    public void DeathSound()
    {
        audioSource.PlayOneShot(death, 0.7f);
        Debug.Log("Playing death sounds");
    }
}
