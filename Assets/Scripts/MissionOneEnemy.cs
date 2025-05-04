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

    CircleCollider2D visionRange;
    CapsuleCollider2D enemyCollider;
    Rigidbody2D rb;

    bool isPlayerSeen;
    bool isInPosition;
    bool isTooClose;
    bool shouldDie;

    Vector3 startPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        visionRange = GetComponent<CircleCollider2D>();
        enemyCollider = GetComponent<CapsuleCollider2D>();

        startPosition = transform.position;
    }

    private void Update()
    {
        isPlayerSeen = visionRange.IsTouchingLayers(LayerMask.GetMask("player"));
        Die();
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
            if (!isTooClose)
                rb.velocity = new Vector3(normalizedMoveVec.x * speedMultiplier * speed, 0f, 0f);

        }
        else if (!isPlayerSeen || !isInPosition)
        {
            Vector3 moveVec = startPosition - transform.position;
            Vector3 normalizedMoveVec = Vector3.Normalize(moveVec);
            rb.velocity = new Vector3(normalizedMoveVec.x * speed, 0f, 0f);
        }
    }

    void Die()
    {
        shouldDie = enemyCollider.IsTouchingLayers(LayerMask.GetMask("playerBullet"));
        if (shouldDie)
        {
            StartCoroutine(WaitDie());
        }
    }

    IEnumerator WaitDie()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

}
