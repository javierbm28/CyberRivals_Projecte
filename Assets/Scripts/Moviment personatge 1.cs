using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentpersonatge1 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _velocidadCorrer;
    private float _velocidadSaltar;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.freezeRotation = true;
        _velocidadCorrer = 5f;
        _velocidadSaltar = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float inpputHorizontal = Input.GetAxisRaw("Horizontal") * _velocidadCorrer;

        if (Input.GetKeyDown(KeyCode.W)) {

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _velocidadSaltar);
        
        }

        _rigidbody2D.velocity = new Vector2(inpputHorizontal, _rigidbody2D.velocity.y);
    }
}
