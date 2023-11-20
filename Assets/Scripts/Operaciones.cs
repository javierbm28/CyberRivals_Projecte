using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Operaciones : MonoBehaviour
{

    public Text operationText;
    public Text[] resultTexts; // Array para las cajas de resultados
    private float timer = 10f;
      
    // Mapeo de teclas a las cajas de respuestas para cada jugador
    private KeyCode[] player1Keys = { KeyCode.E, KeyCode.R, KeyCode.F };
    private KeyCode[] player2Keys = { KeyCode.I, KeyCode.O, KeyCode.L };

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerarOperacionMatematica());
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            StartCoroutine(GenerarOperacionMatematica());
            timer = 10f; // Reinicia el temporizador
        }

        HandlePlayerInput();
    }

    IEnumerator GenerarOperacionMatematica()
    {
        // Genera operandos y operación aleatoria
        int operand1 = Random.Range(1, 11);
        int operand2 = Random.Range(1, 11);
        int result = 0;
        char operation = GetRandomOperation(operand1, operand2, out result);

        // Muestra la operación en el centro de la pantalla arriba
        operationText.text = $"{operand1} {operation} {operand2}";

        // Coloca el resultado correcto en una posición aleatoria del array de resultados
        int correctIndex = Random.Range(0, resultTexts.Length);
        resultTexts[correctIndex].text = result.ToString();

        // Muestra los resultados en las cajas de la interfaz gráfica
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

        return operation;
    }

    void HandlePlayerInput()
    {
        // Jugador 1
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.F))
        {
            CheckAnswer(resultTexts[0].text);
        }

        // Jugador 2
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.L))
        {
            CheckAnswer(resultTexts[0].text);
        }
    }

    void CheckAnswer(string selectedAnswer)
    {
        // Obtener la respuesta correcta
        int correctAnswer = int.Parse(resultTexts[0].text);

        // Comparar la respuesta seleccionada con la correcta
        if (int.Parse(selectedAnswer) == correctAnswer)
        {
            // Acciones para respuesta correcta
            Debug.Log("Respuesta correcta");

            
        }
        else
        {
            // Acciones para respuesta incorrecta
            Debug.Log("Respuesta incorrecta");

            
        }
    }
}
