using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsmenu;
    public GameObject startmenu;
    public GameObject pausemenu;
    public GameObject gameOvermenu;
    public GameObject settingsmenuFromPause;
    public GameObject settingsBG;

    public static SettingsMenu instance;

    [Header("PlayerOptions")]
    public bool player1Chosen;
    public bool player2Chosen;
    public bool player3Chosen;

    public bool fromStart;
    public bool fromGameOver;
    public bool fromPause;

    public GameObject player1button;
    public GameObject player2button;
    public GameObject player3button;

    private void Awake()
    {
        instance = this;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        switch (Andrich.GameStateManager.m_Instance.GetCurrentGameState())
        {
            case Andrich.GameStateManager.GameState.mainMenuSettings:

                Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.mainMenu);

                settingsmenu.SetActive(false);
                startmenu.SetActive(true);
                fromStart = false;

                break;
            case Andrich.GameStateManager.GameState.pauseMenuSettings:

                Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.pauseMenuSettings);

                settingsmenu.SetActive(false);
                pausemenu.SetActive(true);
                fromPause = false;

                break;
            case Andrich.GameStateManager.GameState.gameOverSettings:

                Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.gameOver);

                settingsmenu.SetActive(false);
                gameOvermenu.SetActive(true);
                fromGameOver = false;

                break;
            default:
                break;
        }
    }

    public void Resume()
    {
        //Remember from what screen you came, so you go back to that screen

        
    }

    //choose the skin you want to use
    public void ChoosePlayer1()
    {
        player1Chosen = true;
        player2Chosen = false;
        player3Chosen = false;
    }

    public void ChoosePlayer2() 
    {
        player1Chosen = false;
        player2Chosen = true;
        player3Chosen = false;
    }

    public void ChoosePlayer3() 
    {
        player1Chosen = false;
        player2Chosen = false;
        player3Chosen = true;
    }
}
