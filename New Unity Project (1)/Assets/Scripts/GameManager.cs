using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textoPuntos;

    private int puntosNecesarios;
    private int puntos;

    private void Start()
    {
        puntosNecesarios = FindObjectsOfType<Punto>().Length;
        puntos = 0;
    }

    public void AnadirPunto()
    {
        puntos++;
        textoPuntos.text = puntos.ToString();
        if (puntos >= puntosNecesarios)
        {
            Debug.Log("Has ganado!");
        }
    }
}
