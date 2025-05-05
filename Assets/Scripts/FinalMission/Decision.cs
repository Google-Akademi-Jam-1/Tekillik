using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class Decision : MonoBehaviour
{
    [SerializeField]
    Canvas finalCanvas;
    [SerializeField]
    LevelLoader loader;
    [SerializeField]
    private GameObject[] images;
    [SerializeField]
    private Button myButton;

    public float waitDuration = 3f;
    public float transitionDuration = .5f;

    public void GiveFormula()
    {
        MusicManager.instance.NewLevel("Intro");
        loader.LoadLevelAtIndex(1);
    }
    public void ExitLoop()
    {
        finalCanvas.gameObject.SetActive(false);
        StartCoroutine(DontGiveFormula());
    }

    private void Awake()
    {
        myButton.gameObject.SetActive(false);
        myButton.onClick.AddListener(() => MusicManager.instance.NewLevel("MainMenu"));
    }

    IEnumerator DontGiveFormula()
    {
        images[0].GetComponent<CanvasGroup>().DOFade(1f, transitionDuration);
        yield return new WaitForSeconds(waitDuration);
        images[0].GetComponent<CanvasGroup>().DOFade(0f, transitionDuration);
        images[1].GetComponent<CanvasGroup>().DOFade(1f, transitionDuration);
        yield return new WaitForSeconds(waitDuration);
        images[1].GetComponent<CanvasGroup>().DOFade(0f, transitionDuration);
        images[2].GetComponent<CanvasGroup>().DOFade(1f, transitionDuration);
        yield return new WaitForSeconds(waitDuration);
        myButton.gameObject.SetActive(true);
        myButton.GetComponent<CanvasGroup>().DOFade(1f, transitionDuration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            finalCanvas.gameObject.SetActive(true);
        }
    }

}
