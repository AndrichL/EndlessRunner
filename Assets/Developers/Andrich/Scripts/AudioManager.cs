using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Andrich
{ 
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup m_Main;
        [SerializeField] private AudioMixerGroup m_Music;
        [SerializeField] private AudioMixerGroup m_SFX;
        [SerializeField] private Sound[] m_Sounds;

        public static AudioManager m_Instance { get; private set; }

        [System.Serializable]
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
                Debug.LogWarning("pause sound: " + name + "is not found");
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

        public void SetMainVolume(float Volume)
        {
            m_Main.audioMixer.SetFloat("volume", Volume);
        }

        public void SetMusicVolume(float Volume)
        {
            m_Music.audioMixer.SetFloat("volumeMusic", Volume);
        }

        public void SetSFXVolume(float Volume)
        {
            m_SFX.audioMixer.SetFloat("volumeSFX", Volume);
        }
    }
}
