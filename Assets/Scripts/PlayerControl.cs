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
    bool onGround = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        HandleControls();
    }

    void HandleControls()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Debug.Log("sað tuþa basýlýyor");
            Run(1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Run(-1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        onGround = (feetCollider.IsTouchingLayers(LayerMask.GetMask("platform")));

        if (onGround)
        {
            onGround = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpForce);
        }
    }

    void Run(int direction)
    {
        Debug.Log("I should be running right now");
        rb.velocity = new Vector2(speed * (float) direction, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "light")
        {

        }
    }
}
