using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VanessaMusic.Utilities
{
    public class MusicManager : MonoBehaviour
    {
        public static MusicManager instance;

        AudioSource source;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);

            }
            else
            {
                Destroy(gameObject);

            }

            source = GetComponent<AudioSource>();
        }

        public void SwitchMusic(AudioClip aClip)
        {
            source.clip = aClip;
            source.Play();
        }
    }


}
