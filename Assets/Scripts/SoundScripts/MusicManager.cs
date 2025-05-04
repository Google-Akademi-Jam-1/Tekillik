using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    AudioSource source;
    [SerializeField]
    Sound[] musics;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        // Sahne ismine göre müzik adýný belirle
        if (sceneName == "Mission1")
        {
            PlayMusic("level1 music");
        }
        else if (sceneName == "Mission2")
        {
            PlayMusic("level2 music");
        }
        else if (sceneName == "Mission3")
        {
            PlayMusic("level3");
        }
        else if(sceneName == "Office1" || sceneName == "Office2" || sceneName == "Office3")
        {
            PlayMusic("office music");
        }
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
