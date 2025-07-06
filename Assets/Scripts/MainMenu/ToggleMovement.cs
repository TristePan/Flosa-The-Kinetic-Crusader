using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMovement : MonoBehaviour {
    public Button button;
    public Animator Up_image;
    public Animator Left_image;
    public Animator Right_image;

    private bool imageVisible = false;

    private void Start() {

        // Assicuriamoci che l'immagine sia nascosta all'inizio
        Up_image.gameObject.SetActive(false);
        Left_image.gameObject.SetActive(false);
        Right_image.gameObject.SetActive(false);

        // Aggiungiamo il listener per il clicl del bottone
        button.onClick.AddListener(ToggleImageVisibility);
    }

    private void ToggleImageVisibility() {
        // Attiva l'immagine se non lo è
        if(!Up_image.gameObject.activeSelf && !Left_image.gameObject.activeSelf && !Right_image.gameObject.activeSelf) {
            Up_image.gameObject.SetActive(true);
            Left_image.gameObject.SetActive(true);
            Right_image.gameObject.SetActive(true);
        }

        // Cambiamo la visibilità dell'immagine
        if(imageVisible) {
            Up_image.Play("HideImageFire");
            Left_image.Play("HideImageFire");
            Right_image.Play("HideImageFire");
        } else {
            Up_image.Play("ShowImageFire");
            Left_image.Play("ShowImageFire");
            Right_image.Play("ShowImageFire");
        }
        
        // Aggiorna lo stato di visibilità
        imageVisible = !imageVisible;
    }
}
