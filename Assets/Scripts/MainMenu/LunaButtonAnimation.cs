using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    public Button startButton; // Riferimento al pulsante

    void Start()
    {
        // Associa il metodo OnStartButtonClick all'evento di clic del pulsante
        startButton.onClick.AddListener(OnStartButtonClick);
    }

    void OnStartButtonClick()
    {
        // Aggiungi qui il codice per avviare il livello del gioco
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
