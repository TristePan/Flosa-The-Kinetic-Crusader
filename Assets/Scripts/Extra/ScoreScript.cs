using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int scoreValue = 0; // Current score

    TMP_Text scoreText;

    public static ScoreScript Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        // Update score display
        scoreText.text = $"CURRENT SCORE: {scoreValue}";
    }

    public void ResetScore()
    {
        // Reset the current score
        scoreValue = 0;
    }

    public void AddToScore(int points)
    {
        scoreValue += points;
    }
}
