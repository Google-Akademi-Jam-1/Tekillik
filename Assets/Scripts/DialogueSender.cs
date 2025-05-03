using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSender : MonoBehaviour
{
    // This is for the npc who will talk 

    [SerializeField]
    string[] lines;

    [SerializeField]
    DialogueManager dm;

    [SerializeField]
    Canvas canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dm.lines = lines;
            canvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (canvas.gameObject.activeSelf)
            {
                canvas.gameObject.SetActive(false);
            }
        }
    }

}
