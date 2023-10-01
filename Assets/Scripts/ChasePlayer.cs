using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] public GameController gameController;
    [SerializeField] public Transform target; // Obiekt, za którym pod¹¿amy (bohater)
    [SerializeField] float speed = 5.0f; // Szybkoœæ przeciwnika

    private Rigidbody2D rb; // Referencja do Rigidbody2D
    void Dying()
    {
        gameController.dropCoin(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    public void setTarget(Transform newTarget)
    {
        target = newTarget;   
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "FriendlyBullet")
        {
            Destroy(collision.gameObject);
            Dying();
        }
    }

}
