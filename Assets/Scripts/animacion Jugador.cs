using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacionJugador : MonoBehaviour
{
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void MovimentHorizontal (float movimentHorizontal)
    {
        _animator.SetFloat("velocitat", Mathf.Abs(movimentHorizontal));
    }
}
