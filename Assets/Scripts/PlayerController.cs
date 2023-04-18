using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float xInicial, yInicial;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public AudioClip sonidoSalto;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private bool isGrounded = false;

    [Header("Escalar")]
    [SerializeField] private float velocidadEscalar;
    private BoxCollider2D boxCollider2D;
    private float GravedadInicial;
    private bool escalando;

    [Header("Animator")]
    private Animator animator;

    public static bool muerteExterna = false;
    private bool MirandoDerecha=true;

    //Vida
    public int VidaMaxima = 100;
    public int Vida;
    public Slider BarraVida;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        GravedadInicial = rb.gravityScale;

        xInicial = transform.position.x;
        yInicial = transform.position.y;

        animator = GetComponent<Animator>();

        Vida = VidaMaxima;
        BarraVida.maxValue = VidaMaxima;
        BarraVida.value = Vida;


    }

    void Update()
    {
        // Movimiento horizontal
        float moveX = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", Mathf.Abs(moveX));
        Vector2 movement = new Vector2(moveX * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        // Rotación del sprite en eje x
        if (moveX > 0 && !MirandoDerecha)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

            MirandoDerecha = true;

            
        }
        else if (moveX < 0 && MirandoDerecha)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

            MirandoDerecha = false;
        }

        // Salto
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            AudioManager.Instance.ReproducirSonido(sonidoSalto);
        }

        if (muerteExterna)
        {
            muerteExterna = false;
            //muertePlayer();
        }
    }

    private void FixedUpdate()
    {
        Escalar();
        animator.SetBool("enSuelo", isGrounded);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si está en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Enemigo"))
        {
            TomarDaño(10); // reduce 10 puntos de vida al jugador
            BarraVida.value = Vida;
        }
        else if (collision.gameObject.CompareTag("Boss"))
        {
            TomarDaño(40); // reduce 10 puntos de vida al jugador
            BarraVida.value = Vida;
        }
    }

    private void Escalar()
    {
        float inputY = Input.GetAxis("Vertical");
        if ((inputY != 0 || escalando) && (boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Escalera"))))
        {
            Vector2 velocidadSubida = new Vector2(rb.velocity.x, inputY * velocidadEscalar);
            rb.velocity = velocidadSubida;
            rb.gravityScale = 0;
            escalando = true;
        }
        else
        {
            rb.gravityScale = GravedadInicial;
            escalando = false;
        }

        if (isGrounded)
        {
            escalando = false;
        }
    }

    public void Recolocar()
    {
        if(Vida <=0)
        {
            Vida = 100;
        }

        transform.position = new Vector3(xInicial, yInicial, 0);
    }

    void TomarDaño(int daño)
    {
        Vida -= daño;
        BarraVida.value = Vida;
        if(Vida < 0)
        {
            morir();
        }
    }
    void morir()
    {
        Recolocar();
    }
}