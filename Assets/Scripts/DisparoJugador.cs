using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;

    private bool puedeDisparar = true;
    public float cooldownTime = 0.5f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && puedeDisparar)
        {
            //disparar
            Disparar();
            puedeDisparar = false;
            StartCoroutine(Cooldown());
        }
    }

    private void Disparar()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        puedeDisparar = true;
    }
}