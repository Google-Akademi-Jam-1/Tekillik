using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField]
    Sound[] SFX;

    private List<AudioSource> audioSources = new List<AudioSource>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        AudioSource firstSource = gameObject.AddComponent<AudioSource>();
        audioSources.Add(firstSource);
    }

    public void PlaySoundEffect(string name)
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
            AudioSource source = GetAvailableAudioSource(name);
            source.name = soundEffect2Play.name;
            source.clip = soundEffect2Play.clip;
            source.pitch = soundEffect2Play.pitch;
            source.volume = soundEffect2Play.volume;
            source.Play();
        }
    }
    private AudioSource GetAvailableAudioSource(string name)
    {
        // Boþta bir kaynak varsa onu döndür
        foreach (var src in audioSources)
        {
            if (!src.isPlaying || src.name == name)
                return src;
        }

        // Hepsi doluysa yeni bir tane oluþtur
        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        audioSources.Add(newSource);
        return newSource;
    }
}
