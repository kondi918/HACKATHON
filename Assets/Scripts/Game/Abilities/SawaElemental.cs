using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SawaElemental : MonoBehaviour
{
    [SerializeField] Transform mainCharacter;
    [SerializeField] GameObject bullet;
    private bool isMovingToCharacter = false;
    private int detectionRange = 15;
    [SerializeField] LayerMask[] enemyLayers;
    [SerializeField] float attackSpeed = 8f;
    [SerializeField] float attackCooldown = 2f;
    [SerializeField] Rigidbody2D rb; 
    private float movementSpeed = 5f;
    private float stopTimer = 0.5f;

    private void StopMovement()
    {
        if (stopTimer < 0)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            stopTimer -= Time.deltaTime;
        }

    }
    private bool CheckDistanceToCharacter()
    {
        if(Vector2.Distance(mainCharacter.position, transform.position) > 8)
        {
            stopTimer = Random.Range(0.5f, 1.5f);
            return true;
        }
        StopMovement();
        return false;
    }
    private void Shoot(GameObject enemy)
    {
        if(attackCooldown <= 0)
        {
            Vector2 direction = enemy.transform.position - transform.position;
            float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var bulletClone = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, rotation));
            bulletClone.SetActive(true);
            bulletClone.GetComponent<Rigidbody2D>().velocity += direction.normalized * attackSpeed;
            Destroy(bulletClone, 5f);
            attackCooldown = 2f * ParametersHandler.atackSpeedScale;
        }
        else
        {
            attackCooldown -= Time.deltaTime;
        }
    }
    private void MoveToCharacter()
    {
        Vector2 direction = mainCharacter.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * movementSpeed;
    }
    private void Mechanics()
    {
        if(!isMovingToCharacter)
        {
            
            foreach (var layer in enemyLayers)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange, layer);
                if (colliders.Length > 0)
                {
                    Shoot(colliders.First().gameObject);
                    break;
                }
            }
        }
        else
        {
            MoveToCharacter();
        }
    }
    void Update()
    {
        isMovingToCharacter = CheckDistanceToCharacter();
        Mechanics();
    }
}
