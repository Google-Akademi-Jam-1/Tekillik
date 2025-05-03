using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float jumpForce;

    Rigidbody2D rb;
    bool onGround = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        HandleControls();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.GetMask("platform"))
        {
            onGround = true;
        }
    }

    void HandleControls()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Run(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Run(-1);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        if (onGround)
        {
            onGround = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpForce);
        }
    }

    void Run(int direction)
    {
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "light")
        {

        }
    }
}
