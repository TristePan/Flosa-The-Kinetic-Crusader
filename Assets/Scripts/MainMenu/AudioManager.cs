using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [Header ("---------- Audio Sources ----------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;


    [Header ("---------- Audio Clip ----------")]
    public AudioClip MainMenuMusic;

    private void Start() {
        MusicSource.clip = MainMenuMusic;
        MusicSource.Play();
    }
}
