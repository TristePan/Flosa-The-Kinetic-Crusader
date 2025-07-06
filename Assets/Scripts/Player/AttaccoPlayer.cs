using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttaccoPlayer : MonoBehaviour
{
    [SerializeField] private float cooldownAttacco;
    [SerializeField] private Transform puntoDiScoppio;
    [SerializeField] private float cooldownTimer = 0;
    [SerializeField] private TMP_Text ammoUIText;
    [SerializeField] private TMP_Text activeProjectileUIText;

    
    private int remainingProjectile;
    private int activeProjectile;
    public GameObject projectilePrefab;
    private Animator anim;
    private PlayerMovement playerMovement;
    private Rigidbody2D rigidbody2D;
    
    private void OnEnable() {
        Proiettile.OnProiettileDisattivato += HandleProiettileDisattivato;
    }

    private void OnDisable() {
        Proiettile.OnProiettileDisattivato -= HandleProiettileDisattivato;
    }
    
    public void Reload()
    {
        remainingProjectile = 50;
        UpdateAmmoUI();
    }


    private void Awake()
    {
        //richiamo alle componenti di unity
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        Reload();
        UpdateAmmoUI();
        UpdateActiveProjectileUI();
    }

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;
        //azione dell'attacco 
        if (GetComponent<Salute>().isDead() == false && Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0 && remainingProjectile > 0)
        {
            attacco();
            cooldownTimer = cooldownAttacco;
            remainingProjectile--;
            UpdateAmmoUI();
        }
    }


    private void attacco()
    {
        
        //richiamo animazione attacco
        anim.SetTrigger("Attacco");
        GameObject projectile = Instantiate(projectilePrefab, puntoDiScoppio.position, Quaternion.identity);
        
        float playerSpeed = rigidbody2D.velocity.x;
        projectile.GetComponent<Proiettile>().setSpeed(playerSpeed);
        projectile.GetComponent<Proiettile>().SetDirection(Mathf.Sign(transform.localScale.x));

        //aggiorno il proiettile attivo
        activeProjectile++;
        UpdateActiveProjectileUI();
        
    }
    private void UpdateAmmoUI()
    {
        if (ammoUIText != null)
        {
            ammoUIText.text = remainingProjectile + " / 50";
        }
    }

    private void UpdateActiveProjectileUI()
    {
        if (activeProjectileUIText != null)
        {
            activeProjectileUIText.text = "Active Proiettili: " + activeProjectile;
        }
    }

    private void HandleProiettileDisattivato()
    {
        activeProjectile--;
        UpdateActiveProjectileUI();
    }


}

