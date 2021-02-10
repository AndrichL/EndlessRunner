using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public GameObject player;
    public GameObject playerSpawnPosition;
    public GameObject StartPanel;
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
        StartPanel.SetActive(false);
        Time.timeScale = 1f;
        Instantiate(player, playerSpawnPosition.transform.position, Quaternion.identity);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
