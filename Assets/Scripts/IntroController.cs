using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class IntroController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] images;

    public float waitDuration = 3f;
    public float transitionDuration = .5f;

    public Button myButton;

    void Start()
    {
        myButton.gameObject.SetActive(false);
        // Ardýndan MusicManager'dan çaðrý ekle
        myButton.onClick.AddListener(() => MusicManager.instance.NewLevel("Office1"));
        StartCoroutine(SlideShow());
    }

    IEnumerator SlideShow()
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


}
