using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgsound : MonoBehaviour {

	public AudioSource bgSound;


	public void Start()
	{
		bgSound = GetComponent<AudioSource> ();
	}

	public void StartSound()
	{
		/*AudioListener.volume = 1;
		AudioListener.pause = false;*/
		bgSound.Play ();
	}

	public void muteSound()
	{
		/*AudioListener.pause = true;
		AudioListener.volume = 0;*/
		bgSound.Stop ();
	}
}
