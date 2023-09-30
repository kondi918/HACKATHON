using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LightningBolt", menuName = "Powerup/LightningBolt")]
public class LightningBolt : Powerup
{
    [SerializeField]
    private PowerupStats attackSpeed;
    [SerializeField]
    private PowerupStats projectileSpeed;
    [SerializeField]
    private PowerupStats projectileCount;
    public float GetAttackSpeed() { return attackSpeed.GetValue(skillLevel); }
    public float GetProjectileSpped() { return projectileSpeed.GetValue(skillLevel); }
    public float GetProjectileCount() { return projectileCount.GetValue(skillLevel); }
}
