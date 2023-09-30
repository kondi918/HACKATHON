using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void SelectCharacterButton()
    {
        
    }
    public void SettingsButton()
    {

    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
