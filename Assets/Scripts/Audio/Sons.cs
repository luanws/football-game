using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sons : MonoBehaviour {
    public AudioSource audioSource;
    public static Sons instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void Play(AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
