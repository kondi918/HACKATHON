using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] private Transform target; // Obiekt, za kt�rym pod��amy (bohater)
    [SerializeField] float speed = 5.0f; // Szybko�� przeciwnika

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

            // Normalizuj wektor kierunku, aby zachowa� sta�� pr�dko��
            direction.Normalize();

            // Przesu� przeciwnika w kierunku celu z okre�lon� pr�dko�ci�
            rb.velocity = direction * speed;
        }
        else
        {
            // Je�li cel (bohater) jest nullem, zatrzymaj przeciwnika
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

    private void OnDestroy()
    {
        gameController.TestIfRoomClear();
    }

}
