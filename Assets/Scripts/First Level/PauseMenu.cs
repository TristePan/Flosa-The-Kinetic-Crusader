using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject optionsMenuUI;
    public GameObject controlsMenuUI;
    public GameObject timer;
    public GameObject healthBar;
    public PlayerMovement playerMovement;
    public AttaccoPlayer attaccoPlayer;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused) {
                if(optionsMenuUI.activeSelf) {
                    if(controlsMenuUI.activeSelf) {
                        controlsMenuUI.SetActive(false);
                        optionsMenuUI.SetActive(true);
                    } else {
                    optionsMenuUI.SetActive(false);
                    pauseMenuUI.SetActive(true);
                    }
                } else {
                    Resume();
                    //timer.SetActive(true);
                    //healthBar.SetActive(true);
                }
            } else {
                //timer.SetActive(false);
                //healthBar.SetActive(false);
                Pause();
            }
        }
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        playerMovement.enabled = false;
        attaccoPlayer.enabled = false;
        isPaused = true;
    }

    void Resume() {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        playerMovement.enabled = true;
        attaccoPlayer.enabled = true;
        isPaused = false;
    }

    public void Restart() {
        Time.timeScale = 1f;

        // Reset the score before restarting the game
        ScoreScript scoreScript = FindObjectOfType<ScoreScript>();
        if(scoreScript != null) {
            scoreScript.ResetScore();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}