using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
    AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void SoundPlay(AudioClip se) {
        Debug.Log(audioSource);
        audioSource.PlayOneShot(se);
    }
}
