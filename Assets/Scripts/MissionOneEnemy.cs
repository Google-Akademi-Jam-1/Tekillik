using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class MissionOneEnemy : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float speedMultiplier;

    [SerializeField]
    Transform player;

    [SerializeField]
    float tooCloseTreshold;
    
    [SerializeField] 
    GameObject enemyBullet;

    [SerializeField] Transform 
    bulletSpawnPoint;
    [SerializeField] 
    float fireCooldown = 1f;
    float fireTimer = 0f;


    CircleCollider2D visionRange;
    CapsuleCollider2D enemyCollider;
    Rigidbody2D rb;

    bool isPlayerSeen;
    bool isInPosition;
    bool isTooClose;
    bool shouldDie;

    Vector3 startPosition;
    Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        visionRange = GetComponent<CircleCollider2D>();
        enemyCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();

        startPosition = transform.position;
    }

    private void Update()
    {
        isPlayerSeen = visionRange.IsTouchingLayers(LayerMask.GetMask("player"));
        fireTimer -= Time.deltaTime;
        Move();
    }

    private void Move()
    {
        if (shouldDie) { return; }
        if (isPlayerSeen)
        {
            Vector3 moveVec = player.position - transform.position;
            Vector3 normalizedMoveVec = Vector3.Normalize(moveVec);
            isTooClose = (Mathf.Abs(player.position.x - transform.position.x) <= tooCloseTreshold);
            // Sprite'ı sağa/sola döndür
            if (normalizedMoveVec.x > 0)
                GetComponent<SpriteRenderer>().flipX = false;
            else if (normalizedMoveVec.x < 0)
                GetComponent<SpriteRenderer>().flipX = true;
            
            if (!isTooClose)
                rb.velocity = new Vector3(normalizedMoveVec.x * speedMultiplier * speed, 0f, 0f);

        }
        else if (!isPlayerSeen || !isInPosition)
        {
            Vector3 moveVec = startPosition - transform.position;
            Vector3 normalizedMoveVec = Vector3.Normalize(moveVec);
            // Sprite'ı sağa/sola döndür
            if (normalizedMoveVec.x > 0)
                GetComponent<SpriteRenderer>().flipX = false;
            else if (normalizedMoveVec.x < 0)
                GetComponent<SpriteRenderer>().flipX = true;
            rb.velocity = new Vector3(normalizedMoveVec.x * speed, 0f, 0f);
        }
        animator.SetBool("isWalking", Mathf.Abs(rb.velocity.x) > 0.1f);

        if (isTooClose && isPlayerSeen){
            Shoot();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Die();
        }
    }

    void Die()
    {
        StartCoroutine(WaitDie());
    }

    void Shoot(){
       if(shouldDie) return;

        if(fireTimer <= 0f){
            GameObject bullet = Instantiate(enemyBullet, bulletSpawnPoint.position, Quaternion.identity);

        float directionX = GetComponent<SpriteRenderer>().flipX ? -1f : 1f;

        bullet.GetComponent<BulletBehaviour>().direction = new Vector2(directionX, 0f);

        fireTimer = fireCooldown;
        }
    }

    IEnumerator WaitDie()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

}