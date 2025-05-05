using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq.Expressions;

public class DialogueManager : MonoBehaviour
{
    public string[] lines;


    [SerializeField]
    float textSpeed;

    int index = 0;
    [SerializeField]
    TextMeshProUGUI textComp;

    [SerializeField]
    Canvas canvas;

    public bool isDialogueStarted = false;
    bool writingLine = false;
    public string talker;

    private void Start()
    {
        index = 0;
        textComp.text = string.Empty;
    }

    private void Update()
    {
        if (!isDialogueStarted && Input.GetKeyDown(KeyCode.E))
        {
            textComp.text = string.Empty;
            RunDialogue();
            isDialogueStarted = true;
        }
        else if (writingLine && Input.GetKeyDown(KeyCode.E))
        {
            StopAllCoroutines();
            writingLine = false;
            textComp.text = string.Empty;
            textComp.text = lines[index];
        }
        else if (!writingLine && isDialogueStarted && Input.GetKeyDown(KeyCode.E))
        {
            textComp.text = string.Empty;
            NextLine();
        }
    }

    void RunDialogue()
    {
        index = 0;

        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        index++;
        if (index >= lines.Length)
        {
            isDialogueStarted = false;
            canvas.gameObject.SetActive(false);
            return;
        }
        else
        {
            StartCoroutine(TypeLine());
        }
    }


    public IEnumerator TypeLine()
    {
        writingLine = true;
        foreach (char c in lines[index].ToCharArray())
        {
            textComp.text += c;
            SFXManager.instance.PlaySoundEffect(talker);
            yield return new WaitForSeconds(textSpeed);
        }
        writingLine = false;
    }

}
