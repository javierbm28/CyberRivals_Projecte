using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentpersonatge1 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _velocidadCorrer;
    private float _velocidadSaltar;

    private animacionJugador _animacionJugador1;
    private SpriteRenderer _spriteRendererPersonatge1;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.freezeRotation = true;
        _velocidadCorrer = 5f;
        _velocidadSaltar = 5f;

        _animacionJugador1 = GetComponent<animacionJugador>();
        _spriteRendererPersonatge1 = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float inpputHorizontal = Input.GetAxisRaw("Horizontal") * _velocidadCorrer;
        OrientacioSprite(inpputHorizontal);

        if (Input.GetKeyDown(KeyCode.W)) {

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _velocidadSaltar);
        
        }

        _rigidbody2D.velocity = new Vector2(inpputHorizontal, _rigidbody2D.velocity.y);

        void OrientacioSprite(float inpputHorizontal)
        {
            if (inpputHorizontal > 0) 
            {
                _spriteRendererPersonatge1.flipX = false;
            }
            else if (inpputHorizontal < 0)
            {
                _spriteRendererPersonatge1 .flipX = true;
            }
        }
        _animacionJugador1.MovimentHorizontal(inpputHorizontal);

    }
}
