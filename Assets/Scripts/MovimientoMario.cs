using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMario : MonoBehaviour
{
    public float velocidad = 20f;
    public bool saltar = false;
    public bool enSuelo = false;
    float fuerzaSalto = 12f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private  static Animator animator;
    public GameObject SonidoPowerUp;
    public GameObject SonidoSalto;
    public static bool powerUp;
    public static bool Chiquito;
    public static bool MarioMuere;
    public bool SeChoco = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        powerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        

        Vector2 velocidadTotal = new Vector2(movX * velocidad, rb.velocity.y);
        rb.velocity = velocidadTotal;
        

        if (Input.GetButtonDown("Jump"))
        {
            saltar = true;
            SonidoSalto.gameObject.SetActive(true);
        }
        SonidoSalto.gameObject.SetActive(!saltar);

        animator.SetBool("Salto", !enSuelo);
        animator.SetFloat("VelY", velocidadTotal.y);
        animator.SetFloat("VelX", velocidadTotal.x);
        animator.SetBool("HaChocado", SeChoco);
       // animator. SetBool("MovIzq");

         if (movX < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movX > 0)
        {
           spriteRenderer.flipX = false;
        }

         if(powerUp)
        {
            animator.SetBool("PowerUp", powerUp);
        }
         if(Chiquito)
        {
            animator.SetBool("Chiquito", Chiquito);
        }
         if(MarioMuere)
        {
            animator.SetBool("HaChocado", MarioMuere);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        enSuelo = true;


        if (collision.gameObject.name == "suelo")
        {
            enSuelo = true;
        }
        if (collision.gameObject.name == "BichoMalo")
        {
            SeChoco = true;

            
        }

        
    }
    void FixedUpdate()
    {
        if (saltar && enSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            saltar = false;
            enSuelo = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Setita")
        {
            Destroy(other.gameObject);
            SonidoPowerUp.gameObject.SetActive(true);
            

        }
       


    }

    public static void hacersepequeño()
    {
        Chiquito = true;
        powerUp = false;
        animator.SetBool("PowerUp", powerUp);
        animator.SetBool("Chiquito", Chiquito);

    }
   


}
