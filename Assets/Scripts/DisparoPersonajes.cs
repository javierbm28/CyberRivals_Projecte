using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPersonajes : MonoBehaviour
{

    public KeyCode teclaDisparo; // Espacio para J1, P para J2
    public GameObject prefabBala;
    public float velocidadBala = 10f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(teclaDisparo))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Crea una instancia de la bala en la posici�n del jugador
        GameObject bala = Instantiate(prefabBala, transform.position, Quaternion.identity);

        // A�ade velocidad a la bala en la direcci�n adecuada
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        rbBala.velocity = transform.right * velocidadBala;

        // Destruye la bala despu�s de 2 segundos (ajusta seg�n sea necesario)
        Destroy(bala, 2f);
    }
}
