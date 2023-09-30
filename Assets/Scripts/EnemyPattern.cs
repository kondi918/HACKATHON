using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class NewBehaviourScript : ScriptableObject
{
    public new string name;
    public int health;
    public int damage;
    public float movementSpeed;
    public float attackSpeed;
    public Sprite characterSprite;
}
