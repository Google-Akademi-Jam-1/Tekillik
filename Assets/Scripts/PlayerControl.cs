using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    EnemySoldierController enemySoldierController;

    [SerializeField]
    float speed;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    float waitTimeBeforeRestarting;

    [SerializeField]
    Transform bullet;

    [SerializeField]
    Transform powerSource;

    [SerializeField]
    float bulletSpeed;

    Rigidbody2D rb;
    BoxCollider2D feetCollider;
    CapsuleCollider2D charCollider;
    Animator anim;
    Rigidbody2D bulletRB;

    bool onGround = true;
    bool isDead = false;
    bool isShootEnabled = true;

    private void Awake()
    {
        enemySoldierController = Object.FindObjectOfType<EnemySoldierController>();
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        charCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        rb.velocity = new Vector2(0.0f, rb.velocity.y);
        isShootEnabled = SceneManager.GetActiveScene().buildIndex != 5 && SceneManager.GetActiveScene().buildIndex != 7;
        
        if (isDead) { return; }
        if (charCollider.IsTouchingLayers(LayerMask.GetMask("enemyBullet")))
        {
            Die();
        }

        if (charCollider.IsTouchingLayers(LayerMask.GetMask("soldierView")))
        {
            Die();
            enemySoldierController.Detected();
        }
        HandleControls();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) { return; }
        bool isFalling = (rb.velocity.y < 0);
        
        if (isFalling && feetCollider.IsTouchingLayers(LayerMask.GetMask("platform")))
        {
            anim.SetBool("isJumping", false);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("EnemyBullet"))
    //    {
    //        Destroy(collision.gameObject);
    //        Die();
    //    }
    //}

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
        if (Input.GetKeyDown(KeyCode.Mouse0) && isShootEnabled)
        {
            Shoot();
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
        isDead = true;
        anim.SetTrigger("die");
        SFXManager.instance.PlaySoundEffect("maleDeath");
        StartCoroutine(WaitDie());
    }
    void Shoot()
    {
        bullet.transform.position = powerSource.transform.position;
        Transform newBullet = Instantiate(bullet);
        BulletBehaviour bulletBehave = newBullet.GetComponent<BulletBehaviour>();
        bulletBehave.direction = new Vector2(transform.localScale.x, 0f);
    }

    IEnumerator WaitDie()
    {
        yield return new WaitForSeconds(waitTimeBeforeRestarting);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
