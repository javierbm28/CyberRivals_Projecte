using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionBala : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        // Comprueba si la bala colisiona con el jugador rival
        if (other.CompareTag("JugadorRival"))
        {
            // Destruye la bala
            Destroy(gameObject);
            // Aquí puedes añadir lógica adicional, como restar vida al jugador rival.
        }

        // Comprueba si la bala colisiona con una plataforma (asume que las plataformas tienen el tag "Plataforma")
        if (other.CompareTag("Plataforma"))
        {
            // Destruye la bala
            Destroy(gameObject);
        }
    }
}

