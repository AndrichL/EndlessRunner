using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public GameObject playerSpawnPosition;
    public GameObject StartPanel;

    [Header("PlayerOptions")]
    public GameObject player1;
    public GameObject player2;
    public bool player1Chosen;
    public bool player2Chosen;

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

        if (player1Chosen == true)
        {
            Instantiate(player1, playerSpawnPosition.transform.position, Quaternion.identity);
        }
        else if (player2Chosen == true)
        {
            Instantiate(player2, playerSpawnPosition.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("No player chosen");
        }

        StartPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

  

    public void ChoosePlayer1()
    {
        player1.SetActive(true);
        player2.SetActive(false);
        player1Chosen = true;
        player2Chosen = false;
    }

    public void ChoosePlayer2()
    {
        player2.SetActive(true);
        player1.SetActive(false);
        player1Chosen = false;
        player2Chosen = true;
    }

}
