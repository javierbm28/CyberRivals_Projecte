// Script: bullet
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar colisiones con jugadores y plataformas.
        if (other.CompareTag("Player1"))
        {
            other.GetComponent<VidaJ1>().RestarVida();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player2"))
        {
            other.GetComponent<VidaJ2>().RestarVida();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Plataforma"))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ignorar colisiones con jugadores.
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}
