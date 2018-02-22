using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundd : MonoBehaviour {

	public AudioSource punchS;


	void Start()
	{
		punchS = GetComponent<AudioSource> ();
	}

	public void playSound()
	{
		punchS.Play ();
	}

	}
	
