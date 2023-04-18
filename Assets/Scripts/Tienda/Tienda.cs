using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tienda : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject tiendaUI;
    public int precioVida;
    public int precioTiempo;
    public Text puntos;
    public Button botonCompraVida;
    public Button botonCompraTiempo;

    private void Start()
    {
        tiendaUI.SetActive(false);
        botonCompraVida.onClick.AddListener(ComprarVida);
        botonCompraTiempo.onClick.AddListener(ComprarTiempo);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Desactiva el menú de la tienda y restablece el tiempo a 1.0f
            tiendaUI.SetActive(false);
            Time.timeScale = 1.0f;
        }
        puntos.text = "Puntos: " + gameManager.PuntosTotales.ToString();

        if (gameManager.PuntosTotales >= precioVida)
        {
            botonCompraVida.interactable = true;
        }
        else
        {
            botonCompraVida.interactable = false;
        }

        if (gameManager.PuntosTotales >= precioTiempo)
        {
            botonCompraTiempo.interactable = true;
        }
        else
        {
            botonCompraTiempo.interactable = false;
        }
    }

    public void ComprarVida()
    {
        gameManager.PuntosTotales = gameManager.PuntosTotales - precioVida;
        gameManager.VidasTotales++;
    }

    public void ComprarTiempo()
    {
        gameManager.PuntosTotales = gameManager.PuntosTotales - precioTiempo;
        gameManager.TiempoTotal += 10f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tiendaUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tiendaUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}