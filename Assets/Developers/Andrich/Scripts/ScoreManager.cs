using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Andrich
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager m_Instance { get; private set; }

        [SerializeField] private Text m_IngameScoreText;
        [SerializeField] private float m_MaxScore = 99999;
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

            m_IncreaseSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<Moving>().GetSpeed();
        }

        private void Update()
        {
            float delta = m_IncreaseSpeed * Time.deltaTime;
            m_Score += delta;

            m_Score += Mathf.Clamp(delta, 0, m_MaxScore);
            Debug.Log(m_Score);
        }

        public float GetScore()
        {
            return m_Score;
        }
    }
}
