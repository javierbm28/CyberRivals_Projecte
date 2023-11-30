using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Operaciones : MonoBehaviour
{
    public Text operationText;
    public Text[] resultTexts; 
    private float tiempoOperacion = 10f;
    private float tiempoParaResponder = 9f;
    public float tiempoCongelado = 2f;
    public float velocidadMovimiento = 5f;
    private int bulletsJ1 = 0;
    private int bulletsJ2 = 0;
    public TextMeshProUGUI bulletsText;
    public TextMeshProUGUI bulletsText1;
    private int resultatCorrecteCalculat;
    private Text resultadoCaja1;
    private Text resultadoCaja2;
    private Text resultadoCaja3;

    private int correctPlayer = 0;
    private bool canAnswer = true;

    void Start()
    {
        StartCoroutine(GenerarOperacionMatematica());
    }

    void Update()
    {
        tiempoOperacion -= Time.deltaTime;
        if (tiempoOperacion <= 0f)
        {
            StartCoroutine(GenerarOperacionMatematica());
            tiempoOperacion = 10f;
            canAnswer = true;
        }

        float player1Input = Input.GetAxis("Player1");
        transform.Translate(Vector3.right * player1Input * velocidadMovimiento * Time.deltaTime);

        float player2Input = Input.GetAxis("Player2");
        transform.Translate(Vector3.right * player2Input * velocidadMovimiento * Time.deltaTime);

        if (canAnswer)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.F))
            {
                HandleAnswer(RespuestaCorrecta(), 1);
            }

            if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.L))
            {
                HandleAnswer(RespuestaCorrecta(), 2);
            }
        }
    }

    bool RespuestaCorrecta()
    {
        //El resultat correcte es troba a resultatCorrecteCalculat
        //Tecla E i I capsa 1
        //Tecla R i O capsa 2
        //Tecla F i L capsa 3
        
        if(Input.GetKeyDown(KeyCode.E) || (Input.GetKeyDown(KeyCode.I))){

            //Debug.Log(resultatCorrecteCalculat.ToString() + " - " + GameObject.Find("resultadoCaja1").GetComponent<Text>().text);
            resultadoCaja1 = GameObject.Find("resultadoCaja1").GetComponent<Text>();
            string resultatCorrecteCalculat_Cadena1 = resultatCorrecteCalculat.ToString();

            //Debug.Log(resultatCorrecteCalculat_Cadena1);

            if (resultatCorrecteCalculat_Cadena1.Equals(resultadoCaja1.text))
            {
                return true;
                
            }
            else
            {
                return false;
            }

        }
        else if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.O))
        {
            resultadoCaja2 = GameObject.Find("resultadoCaja2").GetComponent<Text>();
            string resultatCorrecteCalculat_Cadena2 = resultatCorrecteCalculat.ToString();

            if (resultatCorrecteCalculat_Cadena2.Equals(resultadoCaja2.text))
            {
                return true;
            }
            else
            {
                return false;
            }

        }else if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.L))
        {
            resultadoCaja3 = GameObject.Find("resultadoCaja3").GetComponent<Text>();
            string resultatCorrecteCalculat_Cadena3 = resultatCorrecteCalculat.ToString();

            if (resultatCorrecteCalculat_Cadena3.Equals(resultadoCaja3.text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    void HandleAnswer(bool isCorrect, int playerNumber)
    {
        if (isCorrect && correctPlayer == 0)
        {
            correctPlayer = playerNumber;

            if (playerNumber == 1 && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.F)))
            {
                bulletsJ1 += 6;
                bulletsText.text = bulletsJ1.ToString();
            }
            else if (playerNumber == 2 && (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.L)))
            {
                bulletsJ2 += 6;
                bulletsText1.text = bulletsJ2.ToString();
            }
           
            canAnswer = false;
            StartCoroutine(ResetAnswerAfterDelay());
        }
        else
        {
            canAnswer = false;
            StartCoroutine (ResetAnswerAfterDelay());   
        }

        
        //Debug.Log(isCorrect);
    }

    IEnumerator ResetAnswerAfterDelay()
    {
        // Espera un tiempo antes de permitir la respuesta nuevamente
        yield return new WaitForSeconds(tiempoParaResponder);

        // Permite la respuesta nuevamente
        canAnswer = true;
    }

    IEnumerator GenerarOperacionMatematica()
    {
        canAnswer = true;
        correctPlayer = 0;

        int operand1 = Random.Range(1, 10);
        int operand2 = Random.Range(1, 10);
        int result;
        char operation = GetRandomOperation(operand1, operand2, out result);

        operationText.text = $"{operand1} {operation} {operand2}";

        int correctIndex = Random.Range(0, resultTexts.Length);
        resultTexts[correctIndex].text = result.ToString();

        for (int i = 0; i < resultTexts.Length; i++)
        {
            if (i != correctIndex)
            {
                resultTexts[i].text = (result + Random.Range(-5, 6)).ToString();
            }
        }

        yield return null;
    }


    char GetRandomOperation(int operand1, int operand2, out int result)
    {
        int randomOperation = Random.Range(0, 4);
        char operation = ' ';
        result = 0;

        switch (randomOperation)
        {
            case 0:
                operation = '+';
                result = operand1 + operand2;
                break;
            case 1:
                operation = '-';
                result = operand1 - operand2;
                break;
            case 2:
                operation = '*';
                result = operand1 * operand2;
                break;
            case 3:
                operation = '/';
                result = operand1 / operand2;
                break;
        }
        resultatCorrecteCalculat = result;

        return operation;
    }
}


