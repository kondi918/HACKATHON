using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[System.Serializable]
public class GameCharacter
{
    public Sprite characterSprite; 
    public string characterName;
    public Sprite specialAbilitySprite;
    public AnimatorController animator;
}
