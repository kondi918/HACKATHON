using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
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
    [SerializeField] RoomsOperator roomsOperator;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    private float timeOfInvicibility=1.0f;
    private bool isInvincible = false;
    public static int coinCount = 100;

    // Start is called before the first frame update
    void Start()
    {
        character = characterDB.GetCharacter(SettingsController.chosenCharacter);
        animator.runtimeAnimatorController = character.animator;
        gameObject.GetComponent<SpriteRenderer>().sprite = character.characterSprite;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(LayerMask.LayerToName(collision.gameObject.layer) == "EnemyBullet" && !isInvincible)
        {
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
            audioSource.clip = clip;
            audioSource.Play();
        }
        if (LayerMask.LayerToName(collision.gameObject.layer)=="Door" && roomsOperator.checkRoom())
        {
            roomsOperator.loadNext();
        }
    }

    public IEnumerator InvincibilityCoroutine(float timer)
    {
        isInvincible = true;
        yield return new WaitForSeconds(timer);
        isInvincible = false;
        //gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

        // Update is called once per frame
        void Update()
    {
        sr.sprite = character.characterSprite;
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