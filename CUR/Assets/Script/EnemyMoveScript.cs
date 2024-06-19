using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public float speed = 2.0f; // Velocidade de movimento do inimigo

    private Rigidbody2D rb;

    void Start()
    {
        // Obtém o componente Rigidbody2D anexado ao inimigo
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Define a velocidade do inimigo para mover da direita para a esquerda
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
}
