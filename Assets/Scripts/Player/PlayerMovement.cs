using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private float jumpspeed;
    private Rigidbody2D body;
    private Animator anim;
    private bool Salto;

    [SerializeField] private float min_x, max_x, min_y;

    private void InMap()
    {
        if(transform.position.x > max_x)
            transform.position = new Vector2(max_x, transform.position.y);
        if(transform.position.x < min_x)
            transform.position = new Vector2(min_x, transform.position.y);
        if(transform.position.y > min_y)
            transform.position = new Vector2(transform.position.x, min_y);
    }

    private void Awake() {
        //prendere le reference da unity
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        //float horizontalInput = (Input.GetAxis("Horizontal"));
        float horizontalInput = 0;
        if (Input.GetKey(KeyBindingManager.Instance.keyBindings["MoveLeft"]))
        {
            horizontalInput = -1;
        }
        else if (Input.GetKey(KeyBindingManager.Instance.keyBindings["MoveRight"]))
        {
            horizontalInput = 1;
        }
        if(Input.GetKey(KeyBindingManager.Instance.keyBindings["Jump"]))
        {
            if(Salto)
                Saltino();
        }

        //Velocita, due dimensioni x,y
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //controllo rotazione
        if (horizontalInput > 0.01f) {
            transform.localScale = new Vector3(3,3,3);
        } else if (horizontalInput < -0.01f) {
            transform.localScale = new Vector3(-3,3,3);
        }

        //Implementazione Salto
        /*if (Input.GetKey(KeyCode.W) && Salto) {
            Saltino();
        }
        */

        //parametri d'animazione
        anim.SetBool("Corsa", horizontalInput != 0);
        anim.SetBool("Salto", Salto);

        InMap();
    }

    private void Saltino() {
        body.velocity = new Vector2(body.velocity.x, jumpspeed);
        anim.SetTrigger("jump");
        Salto = false; 
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground"))
            Salto = true;
    }

    public void IncreaseJumpSpeed(float amount) {
        jumpspeed += amount;
    }

    public void IncreaseSpeed(float amount) {
        speed += amount;
    }

}