using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    float waitTimeBeforeRestarting;

    Rigidbody2D rb;
    BoxCollider2D feetCollider;
    CapsuleCollider2D charCollider;
    Animator anim;

    bool onGround = true;
    bool isDead = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        charCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (!isDead)
            HandleControls();

        // Die checks in itself if it should die or not
        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isFalling = (rb.velocity.y < 0);
        Debug.Log("Inside on trigger and is Falling is:" + isFalling);
        
        if (isFalling && feetCollider.IsTouchingLayers(LayerMask.GetMask("platform")))
        {
            Debug.Log("I also run");
            anim.SetBool("isJumping", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            isDead = true;
        }
    }

    void HandleControls()
    {
        anim.SetBool("isRunning", false);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            Run(1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            Run(-1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        onGround = feetCollider.IsTouchingLayers(LayerMask.GetMask("platform"));
        if (onGround)
        {
            onGround = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpForce);
            anim.SetBool("isJumping", true);
        }
    }

    void Run(int direction)
    {
        anim.SetBool("isRunning", true);
        rb.velocity = new Vector2(speed * (float) direction, rb.velocity.y);
    }

    void Die()
    {
        if (isDead)
        {
            anim.SetBool("isDead", true);
            //StartCoroutine(WaitDie());
        }
    }

    IEnumerator WaitDie()
    {
        yield return new WaitForSeconds(waitTimeBeforeRestarting);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
