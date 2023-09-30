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

    private float timeOfInvicibility=1.0f;
    private bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        character = characterDB.GetCharacter(SettingsController.chosenCharacter);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(LayerMask.LayerToName(collision.gameObject.layer) == "EnemyBullet" && !isInvincible)
        {
            Debug.Log("TUTAJ DODAC ODEJMOWANIE HP");
            currentHealth -= 1;
            Destroy(collision.gameObject);
            StartCoroutine(InvincibilityCoroutine(timeOfInvicibility));
        }
        else if(LayerMask.LayerToName(collision.gameObject.layer) == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Enemy" && !isInvincible)
        {
            currentHealth -= 1;
            StartCoroutine(InvincibilityCoroutine(timeOfInvicibility));
        }
    }

    IEnumerator InvincibilityCoroutine(float timer)
    {
        isInvincible = true;
        yield return new WaitForSeconds(timer);
        isInvincible = false;

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