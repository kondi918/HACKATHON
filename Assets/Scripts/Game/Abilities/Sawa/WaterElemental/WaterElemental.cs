using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaterElemental", menuName = "Powerup/WaterElemental")]
public class WaterElemental : Powerup
{
    [SerializeField]
    private PowerupStats attackSpeed;
    [SerializeField]
    private PowerupStats durability;
    [SerializeField]
    private PowerupStats projectileCount;
    [SerializeField]
    private PowerupStats projectileSpeed;
    public float GetAttackSpeed() { return attackSpeed.GetValue(skillLevel); }
    public float GetProjectileSpped() { return durability.GetValue(skillLevel); }
    public float GetProjectileCount() { return projectileCount.GetValue(skillLevel); }
    public float GetProjectileSpeed() { return projectileSpeed.GetValue(skillLevel); }
}
