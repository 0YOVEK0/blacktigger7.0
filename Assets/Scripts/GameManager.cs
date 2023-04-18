using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int puntosTotales;
    public float TiempoTotal;
    public float VidasTotales;

    public int PuntosTotales
    {
        get { return puntosTotales; }
        set { puntosTotales = value; }

    }

    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
    }

}
