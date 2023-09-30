using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public CharacterSelection[] characterSelection;
    public int characterCount
    {
        get
        {
            return characterSelection.Length;
        }
    }

    public CharacterSelection GetCharacter(int index) { return characterSelection[index]; }
}
