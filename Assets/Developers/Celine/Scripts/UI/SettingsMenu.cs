using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsmenu;
    public GameObject startmenu;
    public GameObject pausemenu;
    public GameObject gameOvermenu;

    public static SettingsMenu instance;

    [Header("PlayerOptions")]
    public bool player1Chosen;
    public bool player2Chosen;
    public bool player3Chosen;

    public bool fromStart;
    public bool fromGameOver;
    public bool fromPause;

    private void Awake()
    {
        instance = this;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        if (fromStart)
        {
            settingsmenu.SetActive(false);
            startmenu.SetActive(true);
        }
        else if (fromPause)
        {
            settingsmenu.SetActive(false);
            pausemenu.SetActive(true);
        }
        else if (fromGameOver)
        {
            settingsmenu.SetActive(false);
            gameOvermenu.SetActive(true);
        }
    }

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
