using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    string[] lines;

    [SerializeField]
    float textSpeed;

    int index = 0;
    [SerializeField]
    TextMeshProUGUI textComp;

    bool isDialogueStarted = false;
    bool writingLine = false;
    
    private void Start()
    {
        index = 0;
        textComp.text = string.Empty;
    }

    private void Update()
    {
        if (!isDialogueStarted && Input.GetKeyDown(KeyCode.Space))
        {
            textComp.text = string.Empty;
            RunDialogue();
            isDialogueStarted = true;
        }
        else if (writingLine && Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            writingLine = false;
            textComp.text = string.Empty;
            textComp.text = lines[index];
        }
        else if (!writingLine && isDialogueStarted && Input.GetKeyDown(KeyCode.Space))
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
            this.gameObject.SetActive(false);
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
            yield return new WaitForSeconds(textSpeed);
        }
    }

}
