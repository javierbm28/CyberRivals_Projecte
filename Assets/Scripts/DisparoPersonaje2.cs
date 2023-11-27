using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPersonaje2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform FirePoint;
    public GameObject Proyectil;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(Proyectil, FirePoint.position, FirePoint.rotation);
        }
    }
}
