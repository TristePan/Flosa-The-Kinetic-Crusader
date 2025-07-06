using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_2 : MonoBehaviour
{
    [SerializeField] private float speedBoostAmount = 2.0f; 
    [SerializeField] private GameObject powerUpImageUI;

    private void Start()
    {
        if (powerUpImageUI != null)
        {
            powerUpImageUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                //incrementa velocita' salto dallo script
                playerMovement.IncreaseSpeed(speedBoostAmount);
                //suono pick up
                LevelAudioManager.Instance.PlaySFX(LevelAudioManager.Instance.SpeedCollectibleBoost);
                if(powerUpImageUI != null) {
                    powerUpImageUI.SetActive(true);
                }
                Destroy(gameObject);
            }
        }
    }
}
