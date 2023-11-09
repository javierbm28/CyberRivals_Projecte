using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
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
        
    }
}
