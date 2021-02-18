using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

namespace Andrich
{
    public class HighscoreManager : MonoBehaviour
    {
        public static HighscoreManager m_Instance { get; private set; }

        private class Highscores
        {
            public List<HighscoreEntry> m_HighscoreEntryList;
        }

        [System.Serializable]
        private class HighscoreEntry
        {
            public string m_Initials;
            public int m_Score;
        }

        [SerializeField] private InputField m_InputField;

        [SerializeField] private Transform m_EntryParent;
        [SerializeField] private Transform m_EntryTemplate;
        [SerializeField] private Vector2 m_CopyOffset = new Vector2(0, 20);
        [SerializeField] private float m_MaxEntries = 3;

        private List<Transform> m_HighscoreEntryTransformList;
        private string m_ScoreTextKey = "ScoreText";
        private string m_InitialsTextKey = "InitialsText";

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

            m_InputField.onEndEdit.AddListener(delegate { SetInitials(m_InputField.text); });

            m_EntryTemplate.gameObject.SetActive(false);

            SaveSystem.CheckSaveFolder();

            string saveString = SaveSystem.Load();
            Highscores highscores = JsonUtility.FromJson<Highscores>(saveString);

            if(highscores.m_HighscoreEntryList == null)
            {
                highscores.m_HighscoreEntryList = new List<HighscoreEntry>()
                    {
                        new HighscoreEntry{m_Score = 50, m_Initials = "CEL"},
                        new HighscoreEntry{m_Score = 40, m_Initials = "ISA"},
                        new HighscoreEntry{m_Score = 30, m_Initials = "JOR"},
                    };
            }

            //Sort entry list by score
            if (highscores.m_HighscoreEntryList.Count > 0)
            {
                for (int i = 0; i < highscores.m_HighscoreEntryList.Count; i++) //current
                {
                    for (int n = 0; n < highscores.m_HighscoreEntryList.Count; n++) //next
                    {
                        if (highscores.m_HighscoreEntryList[i].m_Score > highscores.m_HighscoreEntryList[n].m_Score)
                        {
                            //Swap
                            HighscoreEntry currentStored = highscores.m_HighscoreEntryList[i];
                            highscores.m_HighscoreEntryList[i] = highscores.m_HighscoreEntryList[n];
                            highscores.m_HighscoreEntryList[n] = currentStored;
                        }
                    }
                }
            }

            m_HighscoreEntryTransformList = new List<Transform>();
            for (int i = 0; i < m_MaxEntries; i++)
            {
                CreateHighscoreEntryTransform(highscores.m_HighscoreEntryList[i], m_EntryParent, m_HighscoreEntryTransformList);
            }

            string json = JsonUtility.ToJson(highscores);
            SaveSystem.Save(json);
        }

        private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
        {
            Transform entryTransform = Instantiate(m_EntryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

            entryRectTransform.anchoredPosition = new Vector2(m_CopyOffset.x * transformList.Count, -m_CopyOffset.y * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int score = highscoreEntry.m_Score;

            entryTransform.Find(m_ScoreTextKey).GetComponent<Text>().text = score.ToString();

            string initial = highscoreEntry.m_Initials;
            entryTransform.Find(m_InitialsTextKey).GetComponent<Text>().text = initial;

            transformList.Add(entryTransform);
        }

        public void AddHighscoreEntry(string initials, int score)
        {
            // Create HighscoreEntry
            HighscoreEntry highscoreEntry = new HighscoreEntry { m_Initials = initials, m_Score = score };

            // Load saved Highscores
            string saveString = SaveSystem.Load();
            Highscores highscores = JsonUtility.FromJson<Highscores>(saveString);

            // Add new entry to Highscores
            highscores.m_HighscoreEntryList.Add(highscoreEntry);

            // Sort highscores
            if (highscores.m_HighscoreEntryList.Count > 0)
            {
                for (int i = 0; i < highscores.m_HighscoreEntryList.Count; i++) //current
                {
                    for (int n = 0; n < highscores.m_HighscoreEntryList.Count; n++) //next
                    {
                        if (highscores.m_HighscoreEntryList[i].m_Score > highscores.m_HighscoreEntryList[n].m_Score)
                        {
                            //Swap
                            HighscoreEntry currentStored = highscores.m_HighscoreEntryList[i];
                            highscores.m_HighscoreEntryList[i] = highscores.m_HighscoreEntryList[n];
                            highscores.m_HighscoreEntryList[n] = currentStored;
                        }
                    }
                }
            }

            // Save updated Highscores
            string json = JsonUtility.ToJson(highscores);
            SaveSystem.Save(json);
            PlayerPrefs.Save();
        }

        public void SetInitials(string value)
        {
            char[] letterAmount = value.ToCharArray();
            Debug.Log(letterAmount.Length);

            if (value.Length >= m_InputField.characterLimit) // Max initials in Input Field is 3
            {
                AddHighscoreEntry(value.ToUpper(), ScoreManager.m_Instance.GetFinalScore()); // Add new highscore
                m_InputField.gameObject.SetActive(false);
            }
        }
    }
}
