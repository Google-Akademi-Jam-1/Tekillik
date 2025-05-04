using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource source;
    [SerializeField]
    Sound[] musics;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayMusic(string name)
    {
        Sound music2Play = null;
        for (int i = 0; i < musics.Length; i++)
        {
            if (musics[i].name == name)
            {
                music2Play = musics[i];
            }

        }

        if(music2Play != null)
        {
            source.clip = music2Play.clip;
            source.pitch = music2Play.pitch;
            source.volume = music2Play.volume;
            source.Play();
        }

    }


}
