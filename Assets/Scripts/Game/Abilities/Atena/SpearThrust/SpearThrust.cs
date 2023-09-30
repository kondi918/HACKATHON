using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpearThrust", menuName = "Powerup/Spear Thrust")]
public class SpearThrust : Powerup
{
    [SerializeField]
    private PowerupStats attackSpeed;
    [SerializeField]
    private PowerupStats spearLenght;
    [SerializeField]
    private PowerupStats thrustCount;
    public float GetAttackSpeed() { return attackSpeed.GetValue(skillLevel); }
    public float GetProjectileSpped() { return spearLenght.GetValue(skillLevel); }
    public float GetProjectileCount() { return thrustCount.GetValue(skillLevel); }
}
