using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 6;
    public int damage = 500;
    public Transform shootPoint;
    public GameObject projectilePrefab;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    void OnBecameInvisible()
    {
        //Destrói a bala quando já está fora da tela
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto colidido possui a tag "Enemy"
        if (other.CompareTag("Inimigo"))
        {
            // Obtém o componente de vida do inimigo
            EnemyHealthScript enemyHealth = other.GetComponent<EnemyHealthScript>();

            // Se encontrou o componente de vida, aplica o dano
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            // Destroi o projétil após causar dano
            Destroy(gameObject);
        }
    }
}