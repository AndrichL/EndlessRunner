using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public static DeathScreen instance;
    public GameObject DeathPanel;
    public GameObject SettingsPanel;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void Death()
    {
        Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.gameOver);

        DeathPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HomeButton()
    {
        Time.timeScale = 1f;
        DeathPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void Settings()
    {
        Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.gameOverSettings);

        DeathPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        SettingsMenu.instance.fromGameOver = true;
    }
}
