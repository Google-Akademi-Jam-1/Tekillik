using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionOneEnemy : MonoBehaviour
{
    CircleCollider2D visionRange;
    Rigidbody2D rb;

    bool isPlayerSeen;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        visionRange = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        isPlayerSeen = visionRange.IsTouchingLayers(LayerMask.GetMask("Player"));
    }

}
