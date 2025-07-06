using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public static GameStatus Instance;
    [SerializeField] private GameDifficulty currentDifficulty = GameDifficulty.Normal;


    // Enum per rappresentare i diversi livelli di difficoltà
    public enum GameDifficulty {
        Easy,
        Normal,
        Hard
    }

    // Singleton Pattern
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Metodo per settare la difficoltà
    public void SetDifficulty(GameDifficulty difficulty)
    {
        currentDifficulty = difficulty;
        Debug.Log($"Game difficulty set to {currentDifficulty}");
    }

    // Metodo per ottenere la difficoltà corrente
    public GameDifficulty GetDifficulty()
    {
        return currentDifficulty;
    }
}
