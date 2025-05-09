using UnityEngine;

public class QuitManager : MonoBehaviour
{
    public GameObject quitPanel; // Riferimento al pannello di conferma

    // Mostra il pannello di conferma
    public void ShowQuitPanel()
    {
        quitPanel.SetActive(true);
    }

    // Nasconde il pannello di conferma
    public void HideQuitPanel()
    {
        quitPanel.SetActive(false);
    }

    // Chiude il gioco
    public void QuitGame()
    {
        Debug.Log("Chiusura del gioco...");
        Application.Quit();
    }
}

