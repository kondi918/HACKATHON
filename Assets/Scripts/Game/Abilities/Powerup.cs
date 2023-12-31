using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : ScriptableObject
{
    [SerializeField]
    public int[] upgradesCosts;

    [SerializeField]
    public int skillLevel;

    [SerializeField]
    public int skillMaxLevel;

    [SerializeField]
    private PowerupStats projectileDamage;
    
    [SerializeField]
    private PowerupStats cooldown;

    public int getCurrentUpgradeCost()
    {
        return upgradesCosts[skillLevel];
    }

    public float GetProjectileDamage() { return projectileDamage.GetValue(skillLevel); }
    public float GetCooldown() { return cooldown.GetValue(skillLevel); }
}
