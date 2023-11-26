using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barron_Mov : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public float JumMax;
    public LayerMask CapaSuelo;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private BoxCollider2D boxCollider;
    private float Horizontal;
    private bool Grounded;
    private float JumpRest;

    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private BarraVida barraVida;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Animator = GetComponent<Animator>();
        JumpRest = JumMax;
        vida = maximoVida;
        barraVida.InicializarBarraVida(vida);
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector2 (-10.0f, 10.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector2(10.0f, 10.0f);

        Animator.SetBool("Caminando", Horizontal != 0.0f);
        Animator.SetBool("EnSuelo",Suelo());
        
        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);

        Jump();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        barraVida.CambiarVidaActual(vida);
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    bool Suelo(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x,boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, CapaSuelo);
        return raycastHit.collider != null;
    }

    private void Jump()
    {
        
        // Rigidbody2D.AddForce(Vector2.up * JumpForce);
        if(Suelo()){
//            Animator.SetBool("Salto", false);
            JumpRest = JumMax;
        }

        if (Input.GetKeyDown(KeyCode.W) && JumpRest > 0)
        {
            JumpRest--;
//           Animator.SetBool("Salto", true);
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x,0f);
            Debug.Log("Jumping!");
            Rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
        Rigidbody2D.position = new Vector2(Mathf.Clamp(Rigidbody2D.position.x, -8.28f, 43.96f),
            Rigidbody2D.position.y);
    }

}