using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    GameCharacter character;
    [SerializeField] GameCharacterDB characterDB;
    Vector2 movement;
    public int currentHealth = 6;
    [SerializeField] float movementSpeed = 0.3f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        character = characterDB.GetCharacter(SettingsController.chosenCharacter);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(LayerMask.LayerToName(collision.gameObject.layer) == "EnemyBullet")
        {
            Debug.Log("TUTAJ DODAC ODEJMOWANIE HP");
            currentHealth -= 1;
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed);
    }
}