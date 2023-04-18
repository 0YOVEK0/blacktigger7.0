using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoDeVida : MonoBehaviour
{
    [SerializeField] private float tiempoDeVida;
    public AudioClip sonidoMuerte;


    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
        AudioManager.Instance.ReproducirSonido(sonidoMuerte);
    }

    

}
