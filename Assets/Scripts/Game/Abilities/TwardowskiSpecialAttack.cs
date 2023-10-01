using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwardowskiSpecialAttack : MonoBehaviour
{
    [SerializeField] float defaultCooldown;         // ZROBIÆ VOID START Z PRZYPISYWANIEM attackCooldown = defaultCooldown
    public float attackCooldown = 5;
    [SerializeField] float attackSpeed = 1f;
    [SerializeField] GameObject bullet;
    [SerializeField] Animator twardowskiAnimator;

    private void CheckCooldown()
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
    }
    private void Shoot()
    {
        if (attackCooldown <= 0)
        {
            var lightningBoltSpawn = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lightningBoltSpawn.z = -2;
            var bulletClone = Instantiate(bullet, lightningBoltSpawn, Quaternion.identity);
            bulletClone.SetActive(true);
            Destroy(bulletClone, 0.4f);
            attackCooldown = 5 * ParametersHandler.atackSpeedScale;
            twardowskiAnimator.Play("TwardowskiLightningBoltCharacter");
            bulletClone.GetComponent<Animator>().Play("TwardowskiLightningBolt");
        }
    }
    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
