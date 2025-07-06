using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Salute : MonoBehaviour
{
    [Header("Salute")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numeroFlickers;
    private SpriteRenderer spriteRend;
    
    private Timer timer; // Reference to Timer script

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

        timer = FindObjectOfType<Timer>(); 
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            // prende danno
            anim.SetTrigger("danneggiato");
            StartCoroutine(Invulnerability());
        }
        else
        {
            // il player è morto
            if (!dead)
            {
                anim.SetTrigger("morto");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                // Starta il GameOver coroutine con un delay
                if (timer != null)
                {
                    StartCoroutine(DelayedGameOver(1.0f));
                }
            }
        }
    }

    //ritarda la morte
    private IEnumerator DelayedGameOver(float delay)
    {
        yield return new WaitForSeconds(delay);
        timer.GameOver();
    }

    public bool isDead()
    {
        return dead;
    }

    private void Update()
    {
        //suicidio - debugging
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        // Duration of invulnerability

        for (int i = 0; i < numeroFlickers; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numeroFlickers * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numeroFlickers * 2));
        }

        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Falling into void
        if (collision.gameObject.tag == "Morte")
        {
            TakeDamage(5);
        }
    }

    /* public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("morto");
        anim.Play("Idle");
        StartCoroutine(Invulnerability());

        foreach (Behaviour component in component)
        {
            component.enabled = true;
        }
    }*/
}
