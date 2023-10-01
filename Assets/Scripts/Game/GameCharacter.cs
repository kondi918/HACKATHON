using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameCharacter
{
    public Sprite characterSprite; 
    public string characterName;
    public Sprite specialAbilitySprite;
    public Sprite normalAbilitySprite;
    //public AnimatorController animator;
    public Powerup[] skills;
}
