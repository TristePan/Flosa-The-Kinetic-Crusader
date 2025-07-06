using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    public static bool isPaused = false;

    public GameObject gameOverUI;
    public GameObject timer;
    public GameObject healthBar;

    void Start() {
        switch (GameStatus.Instance.GetDifficulty()) {
            case GameStatus.GameDifficulty.Easy:
                remainingTime = 90;
                break;
            case GameStatus.GameDifficulty.Normal:
                remainingTime = 60;
                break;
            case GameStatus.GameDifficulty.Hard:
                remainingTime = 45;
                break;
        }
    }

    // Update is called once per frame
    void Update() {
        if(remainingTime > 0) {
            remainingTime -= Time.deltaTime;
        } else if(remainingTime < 0) {
            //Game Over
            remainingTime = 0;
            GameOver();
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void GameOver() {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
        Scoreboard.Instance.AddScoreEntry(ScoreScript.Instance.scoreValue);
        
    }

    public void Restart() {

        Time.timeScale = 1f;

        gameOverUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit() {
        Debug.Log("Exit button clicked");
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Time.timeScale set to 1f");
        Time.timeScale = 1f;
    }
}