using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public static DeathScreen instance;
    public GameObject DeathPanel;
    public GameObject SettingsPanel;
    [SerializeField] private Text m_FinalScoreText;
    [SerializeField] private GameObject m_LeaderBoard;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void Death()
    {
        Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.gameOver);
        Andrich.ScoreManager.m_Instance.HUDSetActive(false);
        m_FinalScoreText.text = Andrich.ScoreManager.m_Instance.GetFinalScore().ToString();
        DeathPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HomeButton()
    {
        Time.timeScale = 1f;
        DeathPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ActivateLeaderBoard()
    {
        DeathPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        m_LeaderBoard.SetActive(true);
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
