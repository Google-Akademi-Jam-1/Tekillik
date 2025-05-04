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
    string talker;

    [SerializeField]
    DialogueManager dm;

    [SerializeField]
    Canvas canvas;

    [SerializeField]
    TextMeshProUGUI tmp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dm.lines = lines;
            canvas.gameObject.SetActive(true);
            SFXManager.instance.PlaySoundEffect(talker);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (canvas.gameObject.activeSelf)
            {
                dm.isDialogueStarted = false;
                tmp.text = string.Empty;
                canvas.gameObject.SetActive(false);
            }
        }
    }

}
