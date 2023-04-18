using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public GameManager gameMamager;
    [SerializeField] Text puntos;
    

    // Update is called once per frame
    void Update()
    {
        puntos.text = gameMamager.PuntosTotales.ToString();
    }
}
