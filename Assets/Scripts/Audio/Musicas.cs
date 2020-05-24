using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicas : MonoBehaviour {
    public AudioClip[] audioClips;
    public AudioSource audioSource;
    public static Musicas instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (!audioSource.isPlaying) {
            audioSource.clip = GetRandomAudioClip();
            audioSource.Play();
        }
    }

    private AudioClip GetRandomAudioClip() {
        return audioClips[Random.Range(0, audioClips.Length)];
    }
}
