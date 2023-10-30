using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocidad = 5.0f;
    public float fuerzaSalto = 0.1f;
    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Vector2 velocidadMovimiento = new Vector2(movimientoHorizontal * velocidad, rb2D.velocity.y);
        rb2D.velocity = velocidadMovimiento;

        if (Input.GetButtonDown("Jump"))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }

     
    }
}
