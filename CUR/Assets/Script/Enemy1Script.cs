using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Script : MonoBehaviour
{

    public int speed = -5;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }
    void OnBecameInvisible()
    {
        //Destr�i a bala quando j� est� fora da tela
        Destroy(gameObject);
    }
}
