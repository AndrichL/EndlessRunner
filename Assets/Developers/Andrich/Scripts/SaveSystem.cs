using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Andrich
{ 
    public class SaveSystem : MonoBehaviour
    {
        public static string m_SaveFolder = Application.dataPath + "/Saves/";

        public static void CheckSaveFolder()
        {
            if (!Directory.Exists(m_SaveFolder))
            {
                // Create save folder
                //Directory.CreateDirectory(m_SaveFolder);
            }
            else
            {
                Debug.Log("Save folder found");
            }
        }

        public static void Save(string saveString)
        {
            File.WriteAllText(m_SaveFolder + "/SaveFile.txt", saveString);
        }

        public static string Load()
        {
            if (File.Exists(m_SaveFolder + "/SaveFile.txt"))
            {
                string saveString = File.ReadAllText(m_SaveFolder + "/SaveFile.txt");
                //Debug.Log("SaveFile exists");
                //Debug.Log(m_SaveFolder);
                return saveString;
            }
            else
            {
                return null;
            }
        }
    }
}
