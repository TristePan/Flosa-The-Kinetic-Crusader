using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour {

    public void MainMenuScene() {
        Debug.Log("Main Menu!");
        SceneManager.LoadScene("MainMenu");
    }

    // Change scene to the first level
    public void Moonlevel () {
        Debug.Log("Play Game!");
        SceneManager.LoadScene("First Level");
    }

    public void QuitGame () {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Credits () {
        Debug.Log("Credits!");
        SceneManager.LoadScene("Credits");
    }

    public void SetQuality (int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
