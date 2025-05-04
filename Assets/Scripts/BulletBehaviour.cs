using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed = 5f;         // Mermi hızı
    public float lifeTime = 3f;      // Merminin kaç saniyede yok olacağı
    public Vector2 direction = Vector2.right; // Gideceği yön (varsayılan: sağa)

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D'yi al
        rb.velocity = direction.normalized * speed; // Mermiyi yönüne doğru gönder

        Destroy(gameObject, lifeTime); // Süre dolunca mermiyi yok et
    }
    
}