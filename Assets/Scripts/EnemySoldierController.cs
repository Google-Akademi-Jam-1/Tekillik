using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySoldierController : MonoBehaviour
{
    [SerializeField]
    GameObject soldier;
    [SerializeField]
    float moveSpeed = 2f, minX, maxX;
    private Animator animator;

    private Rigidbody2D rb;
    public bool detected = false;

    private int direction = 1; // 1 = sað, -1 = sol
    private bool isWaiting = false; // Bekleme kontrolü

    private void Awake()
    {
        animator = soldier.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        detected = false;
    }

    private void Update()
    {
        if (!detected && !isWaiting)
        {
            Move();
        }
    }

    private void Move()
    {
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
        isWaiting = true;
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
        StartCoroutine(DetectedCoroutine());
    }

    IEnumerator DetectedCoroutine()
    {
        detected = true;
        Debug.Log("Detected");
        int animNum = Random.Range(0, 2);
        if (animNum == 0)
        {
            SFXManager.instance.PlaySoundEffect("soldierShoot1");
            animator.SetTrigger("shoot1");
            yield return new WaitForSeconds(1.2f);
        }
        else
        {
            SFXManager.instance.PlaySoundEffect("soldierShoot2");
            animator.SetTrigger("shoot2");
            yield return new WaitForSeconds(1.2f);

        }
        detected = false;
    }
}
