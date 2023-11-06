using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentpersonatge2 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _velocidad;
    private float _velocidadSaltar;

    private animacionJugador _animacionJugador2;
    private SpriteRenderer _spriteRendererPersonatge1;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.freezeRotation = true;
        _velocidad = 5f;
        _velocidadSaltar = 5f;

        _animacionJugador2 = GetComponent<animacionJugador>();
        _spriteRendererPersonatge1 = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput2 = Input.GetAxisRaw("Horizontal2") * _velocidad;
        OrientacioSprite(horizontalInput2);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _velocidadSaltar);

        }

        _rigidbody2D.velocity = new Vector2(horizontalInput2, _rigidbody2D.velocity.y);

        void OrientacioSprite(float horizontalInput2)
        {
            if (horizontalInput2 > 0)
            {
                _spriteRendererPersonatge1.flipX = true;
            }
            else if (horizontalInput2 < 0)
            {
                _spriteRendererPersonatge1.flipX = false;
            }
        }

        _animacionJugador2.MovimentHorizontal(horizontalInput2);

    }
}
