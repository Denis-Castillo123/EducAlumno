using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChelinesM : MonoBehaviour
{

    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direccion;
    public float speed_walk;
    public float speed_run;
    public GameObject target;
    public bool atacando;

    public float rango_vision;
    public float rango_ataque;
    public GameObject rango;
    public GameObject Hit;

    private Rigidbody2D Rigidbody2D;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        ani = GetComponent<Animator>();
        target = GameObject.Find("Barron-Animado");
    }

    // Update is called once per frame
    void Update()
    {
        Comportamientos();
    }

    //Metodo del mecanismo a seguir del enemigo de manera random, como lo son la direccion a avanzar,
    //tiempo de espera, mecanismo de ataque del enemigo
    public void Comportamientos()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_vision && !atacando)
        {
            Rigidbody2D.position = new Vector2(Mathf.Clamp(Rigidbody2D.position.x, -8.01f, 43.59f), Rigidbody2D.position.y);
        ani.SetBool("Run",false);
        ani.SetBool("attack",false);
        cronometro += 1 * Time.deltaTime;
        if(cronometro >= 4)
        {
            rutina = Random.Range(0,2);
            cronometro = 0;
        }

        switch (rutina)
        {
            case 0:
                ani.SetBool("Walk",false);
                break;
            case 1:
                direccion = Random.Range(0,2);
                rutina ++;
                break;
            case 2:

                switch (direccion)
                {
                    case 0:
                        transform.rotation = Quaternion.Euler(0,0,0);
                        transform.Translate(Vector2.right * speed_walk * Time.deltaTime);
                        break;
                    case 1:
                        transform.rotation = Quaternion.Euler(0,180,0);
                        transform.Translate(Vector2.right * speed_walk * Time.deltaTime);
                        break;
                }
                ani.SetBool("Walk",true);
                break;
        }
        }else
        {
            if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_ataque && !atacando)
            {
                if(transform.position.x < target.transform.position.x)
                {
                    ani.SetBool("Walk",false);
                    ani.SetBool("Run",false);
                    transform.Translate(Vector2.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0,0,0);
                    ani.SetBool("attack",true);
                }
                else
                {
                    ani.SetBool("Walk",false);
                    ani.SetBool("Run",false);
                    transform.Translate(Vector2.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0,180,0);
                    ani.SetBool("attack",true);
                }
            }
            else
            {
                if(!atacando)
                {
                    if(transform.position.x < target.transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0,0,0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0,180,0);
                    }
                    ani.SetBool("Walk",false);
                    ani.SetBool("Run",false);
                }
            }
        }
        
    }

    public void Final_Ani()
    {
        ani.SetBool("attack",false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }
    
    public void ColliderWeaponTrue()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = false;
    }

}
