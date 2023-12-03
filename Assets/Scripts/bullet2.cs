// Script: bullet
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f; // Tiempo de vida del proyectil en segundos.

    void Start()
    {
        Destroy(gameObject, lifeTime); // Destruir el proyectil después de cierto tiempo.
    }

    void Update()
    {
        // Mover el proyectil en la dirección del eje X.
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar colisiones con jugadores y plataformas.
        if (other.CompareTag("Player1") || other.CompareTag("Player2") || other.CompareTag("Plataforma"))
        {
            // Puedes agregar lógica adicional aquí según tus necesidades.
            // Por ejemplo, puedes llamar a una función para manejar la colisión con jugadores o plataformas.
            // En este ejemplo, simplemente destruimos el proyectil al impactar con un jugador o plataforma.
            Destroy(gameObject);
        }
    }
}
