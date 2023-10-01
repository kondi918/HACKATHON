using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawaSpecialAbility : MonoBehaviour
{
    [SerializeField] float defaultCooldown;         // ZROBIÆ VOID START Z PRZYPISYWANIEM attackCooldown = defaultCooldown
    public float attackCooldown = 5;
    [SerializeField] GameObject waterElemental;
    [SerializeField] Animator sawaAnimator;
    [SerializeField] Transform mainCharacter;

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
            var bulletClone = Instantiate(waterElemental, mainCharacter.transform.position, Quaternion.identity);
            bulletClone.SetActive(true);
            Destroy(bulletClone, 15f);
            attackCooldown = 20 * ParametersHandler.atackSpeedScale;
            sawaAnimator.Play("SawaAttack");
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
