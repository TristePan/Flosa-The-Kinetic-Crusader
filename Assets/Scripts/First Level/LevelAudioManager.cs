using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelAudioManager : MonoBehaviour {

    [Header ("---------- Audio Sources ----------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header ("---------- Audio Clip ----------")]
    public AudioClip LevelMusic;
    public AudioClip LevelSFX;
    public AudioClip HealCollectiblePickUp;
    public AudioClip SpeedCollectibleBoost;
    public AudioClip JumpCollectibleBoost;

    // Singleton
    public static LevelAudioManager Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        MusicSource.clip = LevelMusic;
        MusicSource.Play();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        // Supponiamo che la scena del menu principale si chiami "MainMenu"
        if (scene.name == "MainMenu") {
            // Ferma la musica e distruggi il GameObject
            MusicSource.Stop();
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }

    private void OnDestroy() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
