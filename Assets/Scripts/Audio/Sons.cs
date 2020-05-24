using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sons : MonoBehaviour {
   public AudioClip[] audioClips;
    public AudioSource audioSource;
    public static Sons instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void Play(string nomeClip) {
        foreach (AudioClip clip in audioClips) {
            if (clip.name == nomeClip) {
                audioSource.clip = clip;
                audioSource.Play();
                break;
            }
        }
    }
}
