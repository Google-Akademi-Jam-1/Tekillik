using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public float scrollSpeed = 30f; // Ne kadar hýzlý hareket edecek
    public RectTransform textTransform;

    private float endY = -20f;

    void Update()
    {
        if (textTransform.anchoredPosition.y < endY)
        {
            textTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        }
    }


}
