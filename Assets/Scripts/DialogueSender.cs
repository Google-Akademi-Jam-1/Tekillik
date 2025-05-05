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

    public string[] talkers;
    public bool talkableObject;
    public int[] playersTalkElements;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dm.talkableObject = talkableObject;
            dm.talkers = talkers;
            dm.playersTalkElements = playersTalkElements;
            dm.talker = talker;
            dm.lines = lines;
            canvas.gameObject.SetActive(true);
            if (talkableObject && talkers[1] == "commander" || talkers[1] == "proffessor")
            {
                MusicManager.instance.StopMusic();
            }
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

    public void PopUpText()
    {
        dm.talkableObject = talkableObject;
        dm.talkers = talkers;
        dm.playersTalkElements = playersTalkElements;
        dm.talker = talker;
        dm.lines = lines;
        canvas.gameObject.SetActive(true);
    }

    public void PopCloseText()
    {
        dm.isDialogueStarted = false;
        tmp.text = string.Empty;
        canvas.gameObject.SetActive(false);
    }

}
