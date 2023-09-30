using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameCharacterDB : ScriptableObject
{
    public GameCharacter[] character;
    public int CharacterCount
    {
        get
        {
            return character.Length;
        }
    }
    public GameCharacter GetCharacter(int index)
    {
        return character[index];
    }

}
