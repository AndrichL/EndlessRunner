using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField] private GameObject m_LeaderBoard;
    [SerializeField] private GameObject m_HUD;
    public GameObject settingsmenu;
    public GameObject startmenu;
    public GameObject pausemenu;
    public GameObject gameOvermenu;
    public GameObject settingsmenuFromPause;
    public GameObject settingsBG;

    public static SettingsMenu instance;

    [Header("PlayerOptions")]
    private static int m_RocketSkinNumber;
    //public bool player1Chosen;
    //public bool player2Chosen;
    //public bool player3Chosen;

    //public bool fromStart;
    //public bool fromGameOver;
    //public bool fromPause;

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
        switch (Andrich.GameStateManager.m_Instance.GetPreviousState())
        {
            case Andrich.GameStateManager.GameState.mainMenu:

                Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.mainMenu);

                startmenu.SetActive(true);

                break;
            case Andrich.GameStateManager.GameState.pauseMenu:

                Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.pauseMenu);

                pausemenu.SetActive(true);

                break;
            case Andrich.GameStateManager.GameState.gameOver:

                Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.gameOver);

                gameOvermenu.SetActive(true);

                break;
            case Andrich.GameStateManager.GameState.leaderBoard:

                Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.leaderBoard);

                m_LeaderBoard.SetActive(true);

                break;
            default:
                break;
        }

        settingsmenu.SetActive(false);

    }

    public void OpenSettings(int value)
    {
        // Open the settings menu from the previous GameState
        Andrich.GameStateManager.GameState arrivedFromState = (Andrich.GameStateManager.GameState)value;
        Andrich.GameStateManager.m_Instance.SetGameState(arrivedFromState); // Just the set the previous state


        switch (arrivedFromState)
        {
            case Andrich.GameStateManager.GameState.mainMenu: // 3

                Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.mainMenuSettings);

                startmenu.SetActive(false);
                SetSettingsActiveFromPause(false);

                break;
            case Andrich.GameStateManager.GameState.pauseMenu: // 4

                Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.pauseMenuSettings);

                pausemenu.SetActive(false);
                SetSettingsActiveFromPause(true);

                break;
            case Andrich.GameStateManager.GameState.gameOver: // 5

                Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.gameOverSettings);

                gameOvermenu.SetActive(false);
                SetSettingsActiveFromPause(false);

                break;
            case Andrich.GameStateManager.GameState.leaderBoard: // 11

                Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.leaderBoardSettings);

                m_LeaderBoard.SetActive(false);
                SetSettingsActiveFromPause(false);

                break;
            default:
                break;
        }
    }

    private void SetSettingsActiveFromPause(bool value)
    {
        settingsmenuFromPause.SetActive(value);

        settingsBG.SetActive(!value);
        player1button.SetActive(!value);
        player2button.SetActive(!value);
        player3button.SetActive(!value);

        settingsmenu.SetActive(true);
    }

    //choose the skin you want to use
    public void SetRocketSkin(int value)
    {
        m_RocketSkinNumber = value;
    }

    public int GetRocketSkinNumber()
    {
        return m_RocketSkinNumber;
    }

}
