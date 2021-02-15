using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public GameObject playerSpawnPosition;
    public GameObject StartPanel;
    public GameObject SettingsPanel;

    [Header("PlayerOptions")]
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {

        if (SettingsMenu.instance.player1Chosen == true)
        {
            Instantiate(player1, playerSpawnPosition.transform.position, Quaternion.identity);
        }
        else if (SettingsMenu.instance.player2Chosen == true)
        {
            Instantiate(player2, playerSpawnPosition.transform.position, Quaternion.identity);
        }  
        else if (SettingsMenu.instance.player3Chosen == true)
        {
            Instantiate(player3, playerSpawnPosition.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(player1, playerSpawnPosition.transform.position, Quaternion.identity);
        }

        StartPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
  
    public void Settings()
    {
        StartPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        SettingsMenu.instance.fromStart = true;
    }
}
