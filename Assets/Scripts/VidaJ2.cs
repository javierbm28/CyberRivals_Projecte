using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJ2 : MonoBehaviour
{
    public Sprite[] _spriteVida= new Sprite[6];
    int totalVida = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite= _spriteVida[totalVida];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestarVida()
    {
        Debug.Log("RestarVida() llamado");
        totalVida--;
        ActualizarSpriteVida();

        if (totalVida <= 0)
        {
            Debug.Log("Jugador 1 derrotado");
        }
    }

    void ActualizarSpriteVida()
    {
        Debug.Log("ActualizarSpriteVida() llamado");
        totalVida = Mathf.Clamp(totalVida, 0, _spriteVida.Length - 1);
        GetComponent<SpriteRenderer>().sprite = _spriteVida[totalVida];
    }
}
