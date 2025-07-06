using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsAudioManager : MonoBehaviour
{
    
    [Header ("---------- Audio Sources ----------")]
    [SerializeField] AudioSource MusicSource;

    [Header ("---------- Audio Clip ----------")]
    public AudioClip CreditsMusic;

    private void Start() {
        MusicSource.clip = CreditsMusic;
        MusicSource.Play();
    }
}
