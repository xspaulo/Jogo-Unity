using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{
    public int maxHealth = 100; // Vida m�xima do inimigo
    private int currentHealth;  // Vida atual do inimigo
    private PointsScript ptScript;

    void Start()
    {
        // Inicializa a vida atual com a vida m�xima no in�cio do jogo
        currentHealth = maxHealth;
        ptScript = GameObject.Find("Pontuacao").GetComponent<PointsScript>();
    }

    // M�todo para receber dano
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        // Verifica se a vida atual � menor ou igual a zero
        if (currentHealth <= 0)
        {
            ptScript.pontos += 1;
            Die();
        }
    }

    // M�todo chamado quando o inimigo morre
    void Die()
    {
        // Destr�i o objeto do inimigo
        Destroy(gameObject);
    }
}
