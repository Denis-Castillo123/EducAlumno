using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    [SerializeField] private ChelinesM enemigos;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

 
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo") && enemigos != null)
        {
            Debug.Log("Colisionando con alumno");
            enemigos.Aprender();
        }

        DestroyItem();
    }


}
