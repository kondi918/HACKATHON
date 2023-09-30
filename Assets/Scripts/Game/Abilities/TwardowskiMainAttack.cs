using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwardowskiMainAttack : MonoBehaviour
{
    private float attackCooldown = 0;
    [SerializeField] float attackSpeed = 1f;
    [SerializeField] Transform mainCharacterTransform;
    [SerializeField] GameObject bullet;
    [SerializeField] Animator twardowskiAnimator;

    private void CheckCooldown()
    {
        if(attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
    }
    private void Shoot()
    {
        if (attackCooldown <= 0 )
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - mainCharacterTransform.position;
            float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var bulletClone = Instantiate(bullet, mainCharacterTransform.position,Quaternion.Euler(0,0,rotation));
            bulletClone.SetActive(true);
            bulletClone.GetComponent<Rigidbody2D>().velocity += direction.normalized * attackSpeed;
            Destroy(bulletClone, 5f);
            attackCooldown = 2f;
            twardowskiAnimator.Play("TwardowskiFireBall");
        }
    }
    private void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            Shoot();
        }
    }
    void Update()
    {
        CheckCooldown();
        CheckInput();
    }
}
