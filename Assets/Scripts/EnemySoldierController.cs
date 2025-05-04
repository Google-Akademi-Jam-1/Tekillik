using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemySoldierController : MonoBehaviour
{
    [SerializeField]
    GameObject soldier;
    [SerializeField]
    float moveSpeed = 2f, minX, maxX;
    [SerializeField]
    private Animator animator;

    private Rigidbody2D rb;

    private int direction = 1; // 1 = sað, -1 = sol
    private bool isWaiting = false; // Bekleme kontrolü

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isWaiting)
        {
            Move();
        }
    }

    private void Move()
    {
        if (isWaiting) return;
        animator.SetBool("isWalking", true);
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);

        // Eðer sýnýra geldiyse, dur ve bekle
        if (transform.position.x >= maxX && direction == 1)
        {
            StartCoroutine(WaitAndTurn(-1));
        }
        else if (transform.position.x <= minX && direction == -1)
        {
            StartCoroutine(WaitAndTurn(1));
        }
    }

    private IEnumerator WaitAndTurn(int newDirection)
    {
        animator.SetBool("isWalking", false);
        isWaiting = true; //bunlar boþuna duruyor çünkü coroutine içindeyiz, bitince direkt isWaiting true oluyor zaten
        rb.velocity = Vector2.zero; // Hareketi durdur
        yield return new WaitForSeconds(2f); // 2 saniye bekle
        direction = newDirection;
        Flip(direction);
        isWaiting = false;
    }

    private void Flip(int dir)
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * dir;
        transform.localScale = scale;
    }

    public void Detected()
    {
        StopAllCoroutines(); //Dönüþler durdu
        StartCoroutine(DetectedCoroutine());
    }

    IEnumerator DetectedCoroutine()
    {
        isWaiting = true;
        rb.velocity = Vector2.zero;
        animator.SetBool("isWalking", false);
        int animNum = Random.Range(0, 2);
        if (animNum == 0)
        {
            SFXManager.instance.PlaySoundEffect("soldierShoot1");

            animator.SetTrigger("shoot1");
        }
        else
        {
            SFXManager.instance.PlaySoundEffect("soldierShoot2");
            animator.SetTrigger("shoot2");
        }
        yield return new WaitForSeconds(1.2f);
        isWaiting = false;
    }

}
