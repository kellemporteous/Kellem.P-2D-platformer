﻿using UnityEngine;
using System.Collections;

public class Sound_Manager : MonoBehaviour {
    AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
	}

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
