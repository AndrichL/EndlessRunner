using Andrich;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public int speed;

    // Update is called once per frame
    void Update()
    {
        //Only being able to move up and down
        if (GameStateManager.m_Instance.GetCurrentGameState() == GameStateManager.GameState.inGame)
        {
            var move = new Vector3(0, Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player hits the planets, its gameover
        if(GameStateManager.m_Instance.GetCurrentGameState() == GameStateManager.GameState.inGame)
        {
            if (collision.tag == "Obstacles")
            {
                Destroy(gameObject);
                DeathScreen.instance.Death();
            }
        }
    }

    public float GetSpeed()
    {
        return speed;
    }
}
