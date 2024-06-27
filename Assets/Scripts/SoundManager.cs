using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance { get; private set;}
    private AudioSource audioSource;

    private void Awake() {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void PlaySound(AudioClip audioClip) {
        audioSource.PlayOneShot(audioClip);
    }

}

