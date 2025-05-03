using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float jumpForce;

    Rigidbody2D rb;
    BoxCollider2D feetCollider;
    Animator anim;

    bool onGround = true;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {

    }
    private void Update()
    {
        HandleControls();
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
}
