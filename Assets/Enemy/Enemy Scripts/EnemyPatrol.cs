using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;


    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initialScale;
    private bool movingLeft;

    public bool isFacingPlayer { get; private set; }

    private int HP = 10;
    public static EnemyPatrol instance;

    public GameObject victoryUI;

    private void Awake()
    {
        if(instance == null) {
            instance = this;
        }

        initialScale = enemy.localScale;

    }

    private void Update()
    {
        // Controlla se il nemico sta mirando verso il giocatore
        CheckFacingDirection();

        if(movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            } 
            else 
            {
                //cambio direzione
                DirectionChange();
            }
        } 
        else 
        {
            if(enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                //cambio direzione
                DirectionChange();
            } 
        }

        //Debug.Log("Posizione Nemico: " + enemy.position.x + " | Direzione: " + (movingLeft ? "Sinistra" : "Destra"));
    }

    public void TakeDamage() {
        HP--;
        if(HP <= 0) {
            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            Victory();
        }
    }

    private void CheckFacingDirection()
    {
        // Se il nemico si muove a sinistra, non può vedere il giocatore
        isFacingPlayer = movingLeft;
        //Debug.Log("Checking Facing Direction: " + isFacingPlayer);
    }

    private void DirectionChange()
    {
        movingLeft = !movingLeft;
        //Debug.Log("Cambio Direzione: " + (movingLeft ? "Sinistra" : "Destra")); // Log per la direzione
    }

    private void MoveInDirection(int _direction)
    {

        enemy.localScale = new Vector3(Mathf.Abs (initialScale.x) * _direction, initialScale.y, initialScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }

    public void Victory() {
        Time.timeScale = 0f;
        Scoreboard.Instance.AddScoreEntry(ScoreScript.Instance.scoreValue);
        victoryUI.SetActive(true);
        //Aggiornare la lista della classifica dei punteggi    
    }

}
