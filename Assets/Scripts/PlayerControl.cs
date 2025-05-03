using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "light")
        {

        }
    }
}
