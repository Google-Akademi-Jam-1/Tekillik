using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Decision : MonoBehaviour
{
    [SerializeField]
    Canvas finalCanvas;
    [SerializeField]
    LevelLoader loader;
    public void GiveFormula()
    {
        MusicManager.instance.NewLevel("Office1");
        loader.LoadLevelAtIndex(2);
    }
    public void ExitLoop()
    {
        loader.LoadNextLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            finalCanvas.gameObject.SetActive(true);
        }
    }
}
