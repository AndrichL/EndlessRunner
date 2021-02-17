using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_HUD;
    public GameObject pausemenu;
    public GameObject settingsmenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }
    }

    public void SetPause()
    {
        switch (Andrich.GameStateManager.m_Instance.GetCurrentGameState())
        {
            case Andrich.GameStateManager.GameState.inGame:
                Time.timeScale = 0f;

                Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.pauseMenu);

                pausemenu.SetActive(true);
                Andrich.ScoreManager.m_Instance.HUDSetActive(false);


                break;
            case Andrich.GameStateManager.GameState.pauseMenu:
                Time.timeScale = 1f;

                Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.inGame);

                settingsmenu.SetActive(false);
                pausemenu.SetActive(false);
                Andrich.ScoreManager.m_Instance.HUDSetActive(true);

                break;
            case Andrich.GameStateManager.GameState.pauseMenuSettings:
                Time.timeScale = 1f;

                Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.inGame);

                settingsmenu.SetActive(false);
                pausemenu.SetActive(false);
                Andrich.ScoreManager.m_Instance.HUDSetActive(true);

                break;
            default:
                break;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //If you go into settings from the pause menu, disable the character buttons
    //public void Settingsmenu()
    //{
    //    Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.pauseMenuSettings);

    //    pausemenu.SetActive(false);
    //    settingsmenu.SetActive(true);
    //    SettingsMenu.instance.fromPause = true;
    //    SettingsMenu.instance.settingsmenuFromPause.SetActive(true);
    //    SettingsMenu.instance.settingsBG.SetActive(false);
    //    SettingsMenu.instance.player1button.SetActive(false);
    //    SettingsMenu.instance.player2button.SetActive(false);
    //    SettingsMenu.instance.player3button.SetActive(false);
    //}
}
