using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Andrich
{ 
    public class GameStateManager : MonoBehaviour
    {
        public static GameStateManager m_Instance { get; private set; }

        private static GameState m_CurrentState;
        private static GameState m_PreviousState;

        public enum GameState
        { 
            notSet = 0,
            starting = 1,
            inGame = 2,

            mainMenu = 3,
            pauseMenu = 4,
            gameOver = 5,

            settingsMenu = 6,
            mainMenuSettings = 7,
            pauseMenuSettings = 8,
            gameOverSettings = 9,
            leaderBoardSettings = 10,

            leaderBoard = 11
        }

        private void Awake()
        {
            if(m_Instance == null)
            {
                m_Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public void SetGameState(GameState newGameState)
        {
            if (newGameState == m_CurrentState)
            {
                return;
            }

            m_PreviousState = m_CurrentState;
            m_CurrentState = newGameState;
        }

        public GameState GetCurrentGameState()
        {
            return m_CurrentState;
        }

        public GameState GetPreviousState()
        {
            return m_PreviousState;
        }
    }
}
