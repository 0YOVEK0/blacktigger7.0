using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoMisilMagico : MonoBehaviour
{
    public GameObject misilMagicoPrefab;
    public float velocidadMisilMagico = 5f;
    public int cantidadMisiles = 3;
    public float rangoBusquedaEnemigo = 10f;

    private GameObject[] enemigos;
    private List<GameObject> misilesActivos = new List<GameObject>();
    public GameObject spriteObject;
    private GameObject spriteToActivate;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (misilesActivos.Count < cantidadMisiles)
            {
                GameObject nuevoMisilMagico = Instantiate(misilMagicoPrefab, transform.position, Quaternion.identity);
                misilesActivos.Add(nuevoMisilMagico);
            }
        }

        for (int i = misilesActivos.Count - 1; i >= 0; i--)
        {
            GameObject misilMagico = misilesActivos[i];
            if (misilMagico == null)
            {
                misilesActivos.RemoveAt(i);
                continue;
            }

            if (enemigos == null || enemigos.Length == 0)
            {
                enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
            }

            GameObject enemigoMasCercano = null;
            float distanciaMasCercana = Mathf.Infinity;
            foreach (GameObject enemigo in enemigos)
            {
                float distanciaEnemigo = Vector3.Distance(misilMagico.transform.position, enemigo.transform.position);
                if (distanciaEnemigo < distanciaMasCercana && distanciaEnemigo < rangoBusquedaEnemigo)
                {
                    enemigoMasCercano = enemigo;
                    distanciaMasCercana = distanciaEnemigo;
                }
            }

            if (enemigoMasCercano != null)
            {
                Vector3 direccionEnemigo = (enemigoMasCercano.transform.position - misilMagico.transform.position).normalized;
                misilMagico.transform.position += direccionEnemigo * velocidadMisilMagico * Time.deltaTime;
            }
            else
            {
                misilMagico.transform.position += transform.up * velocidadMisilMagico * Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            spriteToActivate.SetActive(true);
            StartCoroutine(DisableSpriteAfterDelay(1f));
        }

    }
    IEnumerator DisableSpriteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteToActivate.SetActive(false);
    }
    void Start()
    {
        spriteToActivate = spriteObject;
        spriteToActivate.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemigo")
        {
            Destroy(other.gameObject);
            foreach (GameObject misilMagico in misilesActivos)
            {
                Destroy(misilMagico);
            }
            misilesActivos.Clear();
        }
    }
}
