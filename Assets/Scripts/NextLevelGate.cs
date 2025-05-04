using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelGate : MonoBehaviour
{
    [SerializeField]
    LevelLoader loader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            loader.LoadNextLevel();
        }
    }
}
