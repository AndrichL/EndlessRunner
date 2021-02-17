using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Andrich
{ 
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private Slider m_MasterVolumeSlider;
        [SerializeField] private Toggle m_MusicToggle;
        [SerializeField] private Toggle m_SFXToggle;

        [SerializeField] private AudioMixerGroup m_Master;
        [SerializeField] private AudioMixerGroup m_Music;
        [SerializeField] private AudioMixerGroup m_SFX;
        [SerializeField] private Sound[] m_Sounds;
        private static float m_Volume;

        private string m_MasterKey = "Master";
        private string m_MusicKey = "Music";
        private string m_SFXKey = "SFX";

        public static AudioManager m_Instance { get; private set; }

        [Serializable]
        public class Sound
        {
            public string m_SoundName;

            public AudioMixerGroup m_AudioMixer;

            public AudioClip m_Clip;

            [Range(0f, 1f)]
            public float m_Volume = 1;

            public bool m_Loop;

            [HideInInspector]
            public AudioSource m_Source;
        }

        private void Awake()
        {
            m_Master.audioMixer.SetFloat(m_MasterKey, m_Volume);
            m_MasterVolumeSlider.value = m_Volume;

            if (m_Instance == null)
            {
                m_Instance = this;
            }
            else
            {
                Destroy(this);
            }

            foreach (Sound s in m_Sounds)
            {
                s.m_Source = gameObject.AddComponent<AudioSource>();
                s.m_Source.clip = s.m_Clip;
                s.m_Source.volume = s.m_Volume;
                s.m_Source.loop = s.m_Loop;
                s.m_Source.outputAudioMixerGroup = s.m_AudioMixer;
            }

            m_MusicToggle.onValueChanged.AddListener(delegate { SetToggle(m_MusicToggle, m_MusicToggle.isOn); });
            m_SFXToggle.onValueChanged.AddListener(delegate { SetToggle(m_SFXToggle, m_SFXToggle.isOn); });
        }

        private void SetToggle(Toggle toggle, bool value)
        {
            if(toggle == m_MusicToggle)
            {
                if(toggle.isOn)
                {
                    m_Music.audioMixer.SetFloat(m_MusicKey, -80f);
                }
                else
                {
                    m_Music.audioMixer.SetFloat(m_MusicKey, 1f);
                }
            }
            else if(toggle == m_SFXToggle)
            {
                if(toggle.isOn)
                {
                    m_SFX.audioMixer.SetFloat(m_SFXKey, -80f);
                }
                else
                {
                    m_SFX.audioMixer.SetFloat(m_SFXKey, 1f);
                }
            }
        }

        public void Play(string name)
        {
            Sound s = Array.Find(m_Sounds, sound => sound.m_SoundName == name);
            if (s == null)
            {
                Debug.LogWarning("Play sound: " + name + "is not found");
                return;
            }
            else
            {
                if(s.m_AudioMixer == m_SFX)
                {
                    AudioSource.PlayClipAtPoint(s.m_Clip, transform.position);
                }
                else
                {
                    s.m_Source.Play();
                }
            }
        }

        public void Stop(string name)
        {
            Sound s = Array.Find(m_Sounds, sound => sound.m_SoundName == name);
            if (s == null)
            {
                Debug.LogWarning("Stop sound: " + name + "is not found");
                return;
            }
            else
            {
                s.m_Source.Stop();
            }
        }

        public void Pause(string name)
        {
            Sound s = Array.Find(m_Sounds, sound => sound.m_SoundName == name);
            if (s == null)
            {
                Debug.LogWarning("Pause sound: " + name + "is not found");
                return;
            }
            else
            {
                s.m_Source.Pause();
            }
        }

        public void UnPause(string name)
        {
            Sound s = Array.Find(m_Sounds, sound => sound.m_SoundName == name);
            if (s == null)
            {
                Debug.LogWarning("unpause sound: " + name + "is not found");
                return;
            }
            else
            {
                s.m_Source.UnPause();
            }
        }

        public void SetMasterVolume(float value)
        {
            if(value <= -40)
            {
                value = -80;
            }

            m_Master.audioMixer.SetFloat(m_MasterKey, value);
            m_Volume = value;
        }

        public void SetMusicVolume(float value)
        {
            m_Music.audioMixer.SetFloat(m_MusicKey, value);
        }

        public void SetSFXVolume(float value)
        {
            m_SFX.audioMixer.SetFloat(m_SFXKey, value);
        }
    }
}
