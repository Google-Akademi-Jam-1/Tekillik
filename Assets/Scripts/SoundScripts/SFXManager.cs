using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource source;
    [SerializeField]
    Sound[] SFX;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayMusic(string name)
    {
        Sound soundEffect2Play = null;
        for (int i = 0; i < SFX.Length; i++)
        {
            if (SFX[i].name == name)
            {
                soundEffect2Play = SFX[i];
            }

        }

        if (soundEffect2Play != null)
        {
            source.clip = soundEffect2Play.clip;
            source.pitch = soundEffect2Play.pitch;
            source.volume = soundEffect2Play.volume;
            source.Play();
        }

    }
}
