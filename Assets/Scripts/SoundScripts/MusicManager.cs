using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    AudioSource source;
    [SerializeField]
    Sound[] musics;

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
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        NewLevel(sceneName);
    }
    

    public void NewLevel(string sceneName)
    {
        Debug.Log(sceneName);

        if (sceneName == "Mission1")
        {
            Debug.Log("mission1 geldi");

            source.Stop();
            PlayMusic("level1 music");
        }
        else if (sceneName == "Mission2")
        {
            source.Stop();
            PlayMusic("level2 music");
        }
        else if (sceneName == "Mission3")
        {
            source.Stop();
            PlayMusic("level3");
        }
        else if (sceneName == "Office1" || sceneName == "Office2" || sceneName == "Office3")
        {
            source.Stop();
            PlayMusic("office music");
        }
        else if (sceneName == "Intro" || sceneName == "MainMenu")
        {
            source.Stop();
            PlayMusic("main menu music");
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
