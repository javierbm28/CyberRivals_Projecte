using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCyberRivals : MonoBehaviour
{

    public void EscenaJuego()
    {
        SceneManager.LoadScene("Juego");

    }

    public void EscenaHistoria()
    {
        SceneManager.LoadScene("Historia");
    }

    public void EscenaComoJugar()
    {
        SceneManager.LoadScene("ComoJugar");
    }

    public void EscenaAjustes()
    {
        SceneManager.LoadScene("Ajustes");
    }

}
