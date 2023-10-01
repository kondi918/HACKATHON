using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwardowskiSpecialAttack : MonoBehaviour
{
    [SerializeField] float defaultCooldown = 5f;
    public float attackCooldown = 0;
    [SerializeField] GameObject bullet;
    [SerializeField] Animator twardowskiAnimator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

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
            attackCooldown = defaultCooldown;
            twardowskiAnimator.Play("TwardowskiLightningBoltCharacter");
            bulletClone.GetComponent<Animator>().Play("TwardowskiLightningBolt");
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }
    public void UpgradeSkill(float skillCooldown)
    {
        defaultCooldown = skillCooldown;
    }
    void Update()
    {
        CheckCooldown();
        CheckInput();
    }
}
