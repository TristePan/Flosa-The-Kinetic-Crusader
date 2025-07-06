using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSparo : MonoBehaviour {
    public Button button;
    public Animator image;

    private bool imageVisible = false;

    private void Start() {

        // Assicuriamoci che l'immagine sia nascosta all'inizio
        image.gameObject.SetActive(false);

        // Aggiungiamo il listener per il clicl del bottone
        button.onClick.AddListener(ToggleImageVisibility);
    }

    private void ToggleImageVisibility() {
        // Attiva l'immagine se non lo è
        if(!image.gameObject.activeSelf) {
            image.gameObject.SetActive(true);
        }

        // Cambiamo la visibilità dell'immagine
        if(imageVisible) {
            image.Play("HideImageFire");

        } else {
            image.Play("ShowImageFire");
        }
        
        // Aggiorna lo stato di visibilità
        imageVisible = !imageVisible;
    }
}
