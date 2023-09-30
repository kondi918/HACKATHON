using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform target; // Obiekt, za którym pod¹¿amy (bohater)
    public float speed = 5.0f; // Szybkoœæ przeciwnika

    private Rigidbody2D rb; // Referencja do Rigidbody2D


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Oblicz wektor kierunku od przeciwnika do celu (bohatera)
            Vector2 direction = target.position - transform.position;

            // Normalizuj wektor kierunku, aby zachowaæ sta³¹ prêdkoœæ
            direction.Normalize();

            // Przesuñ przeciwnika w kierunku celu z okreœlon¹ prêdkoœci¹
            rb.velocity = direction * speed;
        }
        else
        {
            // Jeœli cel (bohater) jest nullem, zatrzymaj przeciwnika
            rb.velocity = Vector2.zero;
        }
    }
}
