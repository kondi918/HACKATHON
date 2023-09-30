using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : ScriptableObject
{
    [SerializeField]
    protected int[] upgradesCosts;

    [SerializeField]
    protected int skillLevel;

    [SerializeField]
    protected int skillMaxLevel;
}
