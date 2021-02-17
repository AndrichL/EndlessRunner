using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Andrich
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager m_Instance { get; private set; }
        [SerializeField] private GameObject m_Hud;
        [SerializeField] private Text m_IngameScoreText;
        [SerializeField] private float m_MaxScore = 99999;
        [SerializeField] private float m_SpeedMultiplier = 0.2f;
        private float m_IncreaseSpeed;
        private float m_Score;

        private void Awake()
        {
            if (m_Instance == null)
            {
                m_Instance = this;
            }
            else if (m_Instance != null)
            {
                Destroy(this);
            }
        }

        private void Update()
        {
            if(GameStateManager.m_Instance.GetCurrentGameState() == GameStateManager.GameState.inGame)
            {
                float delta = m_IncreaseSpeed * Time.deltaTime;
                m_Score += delta;

                m_Score += Mathf.Clamp(delta, 0, Mathf.Infinity);
                m_IngameScoreText.text = Mathf.RoundToInt(Mathf.Clamp(m_Score * 10f, 0f, m_MaxScore)).ToString();
            }
        }

        public int GetFinalScore()
        {
            return Mathf.RoundToInt(Mathf.Clamp(m_Score * 10f, 0f, m_MaxScore));
        }

        public void GetCurrentPlayer(Moving player)
        {
            m_IncreaseSpeed = player.GetSpeed() * m_SpeedMultiplier;
        }

        public void HUDSetActive(bool value)
        {
            m_Hud.SetActive(value);
        }
    }
}
