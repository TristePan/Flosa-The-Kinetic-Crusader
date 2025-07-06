using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound; //suono una volta preso il checkpoint
    private Transform currentCheckpoint;
    private Salute playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Salute>();
    }
        public void Respawn()
    {
        transform.position = currentCheckpoint.position; //spostare player posizione attuale
        playerHealth.Respawn; //ripristinare le stats del player
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //ultima collisione = checkpoint attuale
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false; //disattiva checkpoint collider
        }
    }
} */
