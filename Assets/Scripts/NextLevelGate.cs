using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelGate : MonoBehaviour
{
    [SerializeField]
    LevelLoader loader;

    private string[] sceneNames = { "MainMenu", "Intro","Office1", "Mission1", "Office2", "Mission2", "Office3", "Mission3" };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MusicManager.instance.NewLevel(sceneNames[SceneManager.GetActiveScene().buildIndex+1]);
            loader.LoadNextLevel();
        }
    }
}
