using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SawaElemental : MonoBehaviour
{
    [SerializeField] Transform mainCharacter;
    [SerializeField] GameObject bullet;
    private bool isMovingToCharacter = false;
    private int detectionRange = 15;
    [SerializeField] LayerMask[] enemyLayers;
    [SerializeField] float attackSpeed = 8f;
    [SerializeField] float attackCooldown = 2f;

    private bool CheckDistanceToCharacter()
    {
        if(Vector2.Distance(mainCharacter.position, transform.position) > 5)
        {
            return true;
        }
        return false;
    }
    private void Shoot(GameObject enemy)
    {
        Vector2 direction = enemy.transform.position - transform.position;
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var bulletClone = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, rotation));
        bulletClone.SetActive(true);
        bulletClone.GetComponent<Rigidbody2D>().velocity += direction.normalized * attackSpeed;
        Destroy(bulletClone, 5f);
        attackCooldown = 2f * ParametersHandler.atackSpeedScale;
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
    }
    void Update()
    {
        CheckDistanceToCharacter();
        Mechanics();
    }
}
