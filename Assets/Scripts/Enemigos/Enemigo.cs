using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private GameObject efectoMuerte;
    [SerializeField] private float velocidad;
    [SerializeField] private Transform contoladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool moviendoDereha;
    //public GameObject prefabToDrop;

    [Header("Animator")]

    private Rigidbody2D rb;


    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(contoladorSuelo.position, Vector2.down, distancia);
        rb.velocity = new Vector2(velocidad, rb.velocity.x);


        if (informacionSuelo == false)
        {
            Girar();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            Girar();

        }
        else if (collision.gameObject.CompareTag("Enemigo"))
        {
            Girar();
        }
    }
    public void Girar()
    {
        moviendoDereha = !moviendoDereha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(contoladorSuelo.transform.position, contoladorSuelo.transform.position + Vector3.down * distancia);
    }
    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        Destroy(gameObject);    
        //Instantiate(prefabToDrop, transform.position, transform.rotation);
     
    }
}