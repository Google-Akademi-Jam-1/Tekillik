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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            finalCanvas.gameObject.SetActive(true);
        }
    }
}
