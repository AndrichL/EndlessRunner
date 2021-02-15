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
        DeathPanel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void RetryButton()
    {
        Time.timeScale = 1f;
        DeathPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void Settings()
    {
        DeathPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        SettingsMenu.instance.fromGameOver = true;
    }
}
