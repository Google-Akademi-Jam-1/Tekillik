using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Decision : MonoBehaviour
{
    [SerializeField]
    Canvas finalCanvas;
    public void GiveFormula()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitLoop()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

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
            dm.talker = talker;
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
                dm.isDialogueStarted = false;
                tmp.text = string.Empty;
                canvas.gameObject.SetActive(false);
            }
        }
    }

}
