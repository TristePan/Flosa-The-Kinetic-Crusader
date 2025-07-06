using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;

    void Start() {
        switch (GameStatus.Instance.GetDifficulty()) {
            case GameStatus.GameDifficulty.Easy:
                healthValue = 1;
                break;
            case GameStatus.GameDifficulty.Normal:
                healthValue = 1;
                break;
            case GameStatus.GameDifficulty.Hard:
                HealthCollectible.Destroy(gameObject);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Salute>().AddHealth(healthValue);

            //collectible pickup sound
            if (LevelAudioManager.Instance != null)
            {
                LevelAudioManager.Instance.PlaySFX(LevelAudioManager.Instance.HealCollectiblePickUp);
            }

            gameObject.SetActive(false);
        }
    }
}
