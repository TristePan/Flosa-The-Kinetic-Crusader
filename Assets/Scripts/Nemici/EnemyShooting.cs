using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{   
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;

    public Transform playerToShoot; // Il target da seguire (in questo caso il giocatore)
    private float shootingRange = 30f; // Distanza massima entro cui può sparare
    [SerializeField] public LayerMask ground; // Il Layer per gli ostacoli (ad esempio, pavimento o muri)
    // Start is called before the first frame update
    
    private EnemyPatrol enemyPatrol;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyPatrol = GameObject.Find("EnemyPatrol").GetComponent<EnemyPatrol>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        float distanceToPlayer = Vector2.Distance(transform.position, playerToShoot.position);

        if(distanceToPlayer <= shootingRange) {
            
            Vector2 directionToPlayer = (playerToShoot.position - transform.position).normalized; // Calcola la direzione

            // Esegui il Raycast
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, shootingRange, ground);
            // Visualizza il Raycast nella scena
            //Debug.DrawRay(transform.position, directionToPlayer * shootingRange, Color.red);

            if(hit.collider != null) {                 
                //Debug.Log("Il raggio ha colpito: " + hit.collider.name);

                if(hit.collider.CompareTag("Player")) {

                    //Debug.Log("Is facing player: " + enemyPatrol.isFacingPlayer);
                    
                    if(enemyPatrol.isFacingPlayer) {

                        //Debug.Log("Il nemico ti vede e spara!");

                        if(distance < shootingRange) {
                            timer += Time.deltaTime;

                            if(timer > 2) {
                                timer = 0;
                                shoot();
                            }
                        }
                    } else {
                        //Debug.Log("Il nemico non può sparare, è rivolto verso il muro!");
                    }
                } else {
                    //Debug.Log("Il nemico non ti vede!");
                }
            }
        } else {
            //Debug.Log("Il raggio non ha colpito nulla!");
        }

    }

    void shoot() {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
