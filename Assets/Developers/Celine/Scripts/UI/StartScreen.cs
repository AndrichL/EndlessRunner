using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public GameObject playerSpawnPosition;
    public GameObject StartPanel;
    public GameObject SettingsPanel;
    [SerializeField] private GameObject m_Hud;

    [Header("PlayerOptions")]
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.mainMenu);
        Andrich.AudioManager.m_Instance.Play("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.inGame);
        GameObject player;
        //use the player you chose in settings, or use default

        switch (SettingsMenu.instance.GetRocketSkinNumber())
        {
            case 2:
                player = Instantiate(player2, playerSpawnPosition.transform.position, Quaternion.identity);

                break;
            case 3:
                player = Instantiate(player3, playerSpawnPosition.transform.position, Quaternion.identity);

                break;
            default:
                player = Instantiate(player1, playerSpawnPosition.transform.position, Quaternion.identity);
                break;
        }

        Andrich.ScoreManager.m_Instance.GetCurrentPlayer(player.GetComponent<Moving>());
        Andrich.ScoreManager.m_Instance.HUDSetActive(true);

        StartPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
  
    //public void Settings()
    //{
    //    Andrich.GameStateManager.m_Instance.SetGameState(Andrich.GameStateManager.GameState.mainMenuSettings);

    //    StartPanel.SetActive(false);
    //    SettingsPanel.SetActive(true);
    //    //SettingsMenu.instance.fromStart = true;
    //}
}
