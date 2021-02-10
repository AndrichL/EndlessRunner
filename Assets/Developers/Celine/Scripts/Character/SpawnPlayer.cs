using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [Header("PlayerOptions")]
    public GameObject player1;
    public GameObject player2;


    public void ChoosePlayer1()
    {
        player1.SetActive(true);
        player2.SetActive(false);
    }

    public void ChoosePlayer2()
    {
        player2.SetActive(true);
        player1.SetActive(false);
    }

}
