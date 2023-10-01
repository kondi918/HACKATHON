using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwardowskiMainAttack : MonoBehaviour
{
    public float defaultCooldown = 2f;
    public float attackCooldown = 0;
    [SerializeField] GameObject[] skills;
    [SerializeField] float projectileSpeed = 1f;
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
            if (!mouseOnSkillIcon())
            {
                Vector2 direction = mousePosition - mainCharacterTransform.position;
                float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                var bulletClone = Instantiate(bullet, mainCharacterTransform.position, Quaternion.Euler(0, 0, rotation));
                bulletClone.SetActive(true);
                bulletClone.GetComponent<Rigidbody2D>().velocity += direction.normalized * projectileSpeed;
                Destroy(bulletClone, 5f);
                attackCooldown = defaultCooldown;
                twardowskiAnimator.Play("TwardowskiFireBall");
            }
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
    public void UpgradeSkill(float projectileSpeed, float skillCooldown)
    {
        this.projectileSpeed = projectileSpeed;
        defaultCooldown = skillCooldown;
    }

    private bool mouseOnSkillIcon()
    {
        foreach (GameObject skill in skills)
        {
            Vector3 positionOfMouse = Input.mousePosition;
            Vector3 posOfSkil = skill.transform.position;
            posOfSkil -= new Vector3(skill.GetComponent<RectTransform>().sizeDelta.x, skill.GetComponent<RectTransform>().sizeDelta.y / 2);
            Vector3 posOfSkil2 = new Vector3(posOfSkil.x - skill.GetComponent<RectTransform>().sizeDelta.x, posOfSkil.y + skill.GetComponent<RectTransform>().sizeDelta.y);
            if (positionOfMouse.x < posOfSkil.x && positionOfMouse.x > posOfSkil2.x && positionOfMouse.y > posOfSkil.y && positionOfMouse.y < posOfSkil2.y)
            {
                return true;
            }
            
        }
        return false;
    }
}