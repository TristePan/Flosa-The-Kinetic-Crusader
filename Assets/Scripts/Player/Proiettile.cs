using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proiettile : MonoBehaviour
{
    public delegate void OnHitDelegate(Collider2D collider);
    public event OnHitDelegate OnHit;
    public static event System.Action OnProiettileDisattivato;

    [SerializeField] private float speed;
    [SerializeField] private float baseSpeed;
    private bool hit;
    private float direzione;

    private BoxCollider2D boxCollider;
    private Animator anim;

    private void Awake()
    {
        // Inizializzare componenti
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Velocita' e direzione proiettile
        if (hit) return;
        float movementSpeed = ((Mathf.Abs(speed) + baseSpeed) * Time.deltaTime * direzione);
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Trigger the hit event
        OnHit?.Invoke(collision);

        if (collision.CompareTag("Enemy"))
        {
            ScoreScript.Instance.scoreValue += 10;
            EnemyPatrol.instance.TakeDamage();
        }

        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("Esplosione");
    }

    public void SetDirection(float _direzione)
    {
        // Set the direction of the projectile
        direzione = _direzione;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        // Adjust the direction based on the sign
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != Mathf.Sign(_direzione))
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void disattiva()
    {
        gameObject.SetActive(false);
        OnProiettileDisattivato?.Invoke();
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    //metodo OnHit delegate
    public void OnHitEnemy(Collider2D collider)
    {
        //Check vari, aggiungere enemy health or trigger effects
        if (collider.CompareTag("Enemy"))
        {
            // quando colpisce nemico
            Debug.Log("Nemico colpito con successo!");
            
        }
        if (collider.CompareTag("Ground"))
        {
            // quando colpisce pavimento
            Debug.Log("Pavimento colpito con successo!");
        }

    }

    private void Start()
    {
        // notifica altre classi oppure objects quando succede qualcosa 
        OnHit += OnHitEnemy;
    }
}
