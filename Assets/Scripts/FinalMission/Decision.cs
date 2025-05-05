using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Decision : MonoBehaviour
{
    public void GiveFormula()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitLoop()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
