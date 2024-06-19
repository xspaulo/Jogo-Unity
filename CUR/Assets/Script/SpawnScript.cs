using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject inimigo1;
    public GameObject inimigo2;
    public GameObject inimigo3;
    public float escolha;


    public float spawnTime = 2;
    void Start()
    {
        // Chamar a função 'addEnemy' a cada 'spawnTime' segundos
        InvokeRepeating("addEnemy", spawnTime, spawnTime);
    }
    // Nova função para clonar/spawn um Asteroide
    void addEnemy()
    {
        float randomValue = Random.Range(0f, 3f);

        // Variável para armazenar a posição X do objeto spawn.
        Renderer renderer = GetComponent<Renderer>();
        var y1 = transform.position.y - renderer.bounds.size.y / 2;
        var y2 = transform.position.y + renderer.bounds.size.y / 2;

        // Aleatoriamente escolhe um ponto dentro do objeto spawn
        var spawnPoint = new Vector2(transform.position.x, Random.Range(y1, y2));

        var escolha = gameObject;
        if (randomValue <= 1f)
        {
            escolha = inimigo1;
        }
        else if (randomValue < 2f)
        {
            escolha = inimigo2;
        }
        else
        {
            escolha = inimigo3;
        }

        // Criar um Asteroide na posição 'spawnPoint'
        var enemy = Instantiate(escolha, spawnPoint, Quaternion.identity);
    }
}