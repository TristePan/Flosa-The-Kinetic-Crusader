using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float jumpBoostAmount = 2.2f; 
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
                //ncrementa velocita' movimento
                playerMovement.IncreaseJumpSpeed(jumpBoostAmount);
                //suono pick up
                LevelAudioManager.Instance.PlaySFX(LevelAudioManager.Instance.JumpCollectibleBoost);
                if(powerUpImageUI != null) {
                    powerUpImageUI.SetActive(true);
                }

                Destroy(gameObject);
            }
        }
    }
}
