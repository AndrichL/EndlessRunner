using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Andrich
{ 
    public class GameStateManager : MonoBehaviour
    {
        public static GameStateManager m_Instance { get; private set; }

        private GameState m_CurrentState;
        private GameState m_PreviousState;

        public enum GameState
        { 
            notSet,
            starting,
            inGame,

            mainMenu,
            pauseMenu,
            gameOver,

            mainMenuSettings,
            pauseMenuSettings,
            gameOverSettings,

            mainMenuHighscores,
            gameOverHighscores,
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
                return;

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
