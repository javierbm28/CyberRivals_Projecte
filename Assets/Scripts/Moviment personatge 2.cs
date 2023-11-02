using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentpersonatge2 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _velocidad;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.freezeRotation = true;
        _velocidad = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput2 = Input.GetAxisRaw("Horizontal2") * _velocidad;

        _rigidbody2D.velocity = new Vector2(horizontalInput2, _rigidbody2D.velocity.y);

    }
}
