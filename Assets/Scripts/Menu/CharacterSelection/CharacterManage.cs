using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class CharacterManage : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public TMP_Text nameText;
    private Image artworkSprite;

    private int selectedOption = 0;
    void Start()
    {
        artworkSprite = GetComponent<Image>();
        UpdateCharacter(this.selectedOption);
    }

    public void nextOption()
    {
        this.selectedOption++;
        if(this.selectedOption >= characterDB.characterCount)
        {
            this.selectedOption = 0;
        }
        UpdateCharacter(this.selectedOption);
    }

    public void previousOption()
    {
        this.selectedOption--;
        if (this.selectedOption < 0)
        {
            this.selectedOption = characterDB.characterCount-1;
        }

        UpdateCharacter(this.selectedOption);
    }

    private void UpdateCharacter(int selectedOption)
    {
        CharacterSelection character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
        GetComponent<RectTransform>().sizeDelta = character.sizeOfImage;
    }

    public void ChooseCharacter()
    {
        SettingsController.chosenCharacter = this.selectedOption;
        SceneManager.LoadScene("Menu");
    }
}
