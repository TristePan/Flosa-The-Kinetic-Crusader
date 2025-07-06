using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    // Funzione chiamata dal bottone
    public void QuitGame()
    {
        // Questo funziona solo in build
        Application.Quit();

        // Questo serve per verificare che funzioni in Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
