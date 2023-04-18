using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float da�o;
    public AudioClip sonidoBala;

    private Transform jugador;

    private void Start()
    {
        // Busca el objeto jugador en la escena
        jugador = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        // Calcula la direcci�n de la mirada del jugador
        Vector2 direccion = jugador.right;

        // Mueve la bala hacia el jugador
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        AudioManager.Instance.ReproducirSonido(sonidoBala);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemigo"))
        {
            other.GetComponent<Enemigo>().TomarDa�o(da�o);
            Destroy(gameObject);
        }
        if (other.CompareTag("Boss"))
        {
            other.GetComponent<Boss>().TomarDa�o(da�o);
            Destroy(gameObject);
        }
    }
}
