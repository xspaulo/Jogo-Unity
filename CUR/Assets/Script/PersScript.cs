using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PersScript : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do proj�til
    public Transform shootPoint; // Ponto de onde os proj�teis ser�o disparados
    public int speed = 10; // Velocidade do proj�til
    private int vida = 3;
    public Text vidaUI;

    private bool isShooting = false; // Flag para controlar se est� disparando

    void Start()
    {
        // Inicia a coroutine para disparar proj�teis
        StartCoroutine(ShootProjectile());
    }

    void Update()
    {
        MoveHorizontal();
        MoveVertical();
        PreventLeavingScreen();
        vidaUI.text = "Vida: " + vida;

        // Verifica se a tecla de espa�o est� sendo pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShooting = true;
        }
        // Verifica se a tecla de espa�o foi solta
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isShooting = false;
        }
    }

    void MoveHorizontal()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);
    }

    void MoveVertical()
    {
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, vertical, 0);
    }

    void PreventLeavingScreen()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -8.3f, 8.3f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4.3f, 4.3f);
        transform.position = clampedPosition;
    }

    IEnumerator ShootProjectile()
    {
        while (true)
        {
            // Espera at� que isShooting seja verdadeiro
            while (!isShooting)
            {
                yield return null; // Aguarda um quadro
            }

            // Calcula a posi��o inicial da bala
            Vector3 initialPosition = shootPoint.position + new Vector3(1.5f, 0.2f, 0); // Exemplo: offset de 0.6 unidades acima do shootPoint

            // Dispara o proj�til
            Instantiate(projectilePrefab, initialPosition, Quaternion.identity);

            // Aguarda 1 segundo antes de permitir outro disparo
            yield return new WaitForSeconds(1f);
        }
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "Inimigo")
        {
            vida = vida - 1; // Cada colisao perde uma vida
            Destroy(outro.gameObject);
            if (vida == 0)
            {
                vidaUI.text = "Vida: " + vida;
                // Quando topar 3 vezes com o inimigo, a nave morre
                Destroy(this.gameObject);
            }
        }

    }
}