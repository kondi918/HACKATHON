using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;

public class UIController : MonoBehaviour
{

    GameCharacter character;
    [SerializeField] GameCharacterDB characterDB;

    [SerializeField] private Sprite[] hearthSprites;
    [SerializeField] private GameObject hearth;
    private List<GameObject> hearthsOnScreen = new List<GameObject>();


    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameObject coin;


    [SerializeField] private GameObject[] skillsIcons;
    
    private Transform canvasTransform;
    private int health = 6;
    private int maxHealth = 10;
    private int curHealth = 6;

    [SerializeField] private Powerup[] skills;
    [SerializeField] private Powerup[] skillsTwardowski;
    [SerializeField] private Powerup[] skillsSawa;


    [SerializeField] GameObject player;
    [SerializeField] GameObject[] sawaAbilities;
    [SerializeField] GameObject[] twardowskiAbilities;

    [SerializeField] private Slider mainSkillCooldown;
    private GameObject mainSkill;

    [SerializeField] private Slider secondSkillCooldown;
    private GameObject secondSkill;

    [SerializeField] private GameObject[] skillDescriptions;
    private string mainAtackTwardtxt;
    private string secondAtackTwardtxt;


    private string mainAtackTxt;
    private string secondAtackTxt;
    private string extraAtackTxt;
    //private
    private bool showInfoIsActive = false;

    private int hero = SettingsController.chosenCharacter;

    // Start is called before the first frame update
    void Start()
    {
        character=characterDB.GetCharacter(SettingsController.chosenCharacter);
        skillsIcons[0].GetComponent<Image>().sprite = character.normalAbilitySprite;
        skillsIcons[1].GetComponent<Image>().sprite = character.specialAbilitySprite;
        mainAtackTwardtxt = "Fireball" + "\n" + "The main attack of Twardowski. He throws a fireball in a direction of a player";
        secondAtackTwardtxt = "ThunderBolt" + "\n" + "Second attack skill of Twardowski. He calls a thunder to a small area.";
        if (hero == 0)
        {
            skills = skillsTwardowski;
            mainAtackTxt = mainAtackTwardtxt;
            secondAtackTxt= secondAtackTwardtxt;
            extraAtackTxt = "";
            mainSkill = twardowskiAbilities[0];
            secondSkill = twardowskiAbilities[1];
        }
        else
        {
            skills = skillsSawa;
            mainAtackTxt = mainAtackTwardtxt;
            secondAtackTxt = secondAtackTwardtxt;
            extraAtackTxt = "";
            mainSkill = sawaAbilities[0];
            secondSkill= sawaAbilities[1];

            //to do sawa like twardowski
        }
        //creating hearths objects
        canvasTransform = GetComponent<Transform>();
        createHearths(3);

        //creating coin object
        coin=Instantiate(coin, Vector3.zero, Quaternion.Euler(0,0,0));
        coin.transform.parent = canvasTransform;

    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<MainCharacter>().currentHealth;
        //testing
        showInfoIsActive = false;
        updateHealth(health);
        updateCoins(MainCharacter.coinCount);
        updateSkills();
        skillbarsUpdate();
        if (!showInfoIsActive) {
        
                foreach (GameObject description in skillDescriptions)
                {
                    description.SetActive(false);
                }
        }
        
    }

    private void createHearths(int quantityOfHearth)
    {
        int xCoordinate = 50;
        for (int  i = 0;  i < quantityOfHearth;  i++)
        {
            hearthsOnScreen.Add(Instantiate(hearth, new Vector3(xCoordinate, 50, 0), Quaternion.Euler(0, 0, 0)));
            hearthsOnScreen[hearthsOnScreen.Count - 1].transform.parent = canvasTransform;
            xCoordinate += 75;
        }
    }

    private void addHearth()
    {
        if (curHealth != maxHealth)
        {
            int xCoordinate = (int)hearthsOnScreen[hearthsOnScreen.Count - 1].transform.position.x + 75;
            hearthsOnScreen.Add(Instantiate(hearth, new Vector3(xCoordinate, 50, 0), Quaternion.Euler(0, 0, 0)));
            hearthsOnScreen[hearthsOnScreen.Count - 1].transform.parent = canvasTransform;
            curHealth += 2;
        }
    }

    private void updateHealth(int health)
    {
        int healthIndex = health / 2;
        int hearthStatus = health % 2;
        foreach (GameObject hearth in hearthsOnScreen)
        {
           hearth.GetComponent<Image>().sprite = hearthSprites[0];
        }
        for (int i = 0; i<healthIndex; i++)
        {
           // Debug.Log(hearthsOnScreen.Count);    
            hearthsOnScreen[i].GetComponent<Image>().sprite = hearthSprites[2];
        }
        if (hearthStatus == 1)
        {
            hearthsOnScreen[healthIndex].GetComponent<Image>().sprite= hearthSprites[1];
        }
    }

    private void createScills()
    {

    }

    private void updateSkills()
    {
        for(int i = 0; i<skillsIcons.Length; i++)
        {
            Vector3 positionOfMouse = Input.mousePosition;
            positionOfMouse.x -= skillsIcons[i].GetComponent<RectTransform>().sizeDelta.x*1.5f;
            Vector3 posOfSkil = skillsIcons[i].transform.position;
            posOfSkil -= new Vector3(skillsIcons[i].GetComponent<RectTransform>().sizeDelta.x, skillsIcons[i].GetComponent<RectTransform>().sizeDelta.y / 2);
            Vector3 posOfSkil2 = new Vector3(posOfSkil.x - skillsIcons[i].GetComponent<RectTransform>().sizeDelta.x, posOfSkil.y + skillsIcons[i].GetComponent<RectTransform>().sizeDelta.y);
            if (positionOfMouse.x < posOfSkil.x && positionOfMouse.x > posOfSkil2.x && positionOfMouse.y > posOfSkil.y && positionOfMouse.y < posOfSkil2.y)
            {
                if (skillsIcons[i].active == true)
                {
                    showInfo(i);
                }
                
            }
                if (skillsIcons[i].active!=true || skills[i].skillLevel == skills[i].skillMaxLevel)
            {
                makeSkillUnactive(i);
                continue;
                
            }
            if (MainCharacter.coinCount >= skills[i].getCurrentUpgradeCost())
            {
                skillsIcons[i].GetComponent<SkillUpgrade>().isActive = true;
                makeSkillActive(i);
            }
            if (skillsIcons[i].GetComponent<SkillUpgrade>().isClicked == true)
            {
                skillsIcons[i].GetComponent<SkillUpgrade>().isClicked = false;
                skillsIcons[i].GetComponent<SkillUpgrade>().isActive = false;
                makeSkillUnactive(i);
                MainCharacter.coinCount -= skills[i].getCurrentUpgradeCost();
                skills[i].skillLevel++;
            }
        }
    }

    private void showInfo(int option)
    {
        showInfoIsActive = true;
        switch (option)
        {
            case 0:
                skillDescriptions[0].SetActive(true);
                skillDescriptions[0].GetComponentInChildren<TextMeshProUGUI>().text = mainAtackTxt;
                break;
            case 1:
                skillDescriptions[1].SetActive(true);
                skillDescriptions[1].GetComponentInChildren<TextMeshProUGUI>().text = secondAtackTxt;
                break;
            case 2:
                skillDescriptions[2].SetActive(true);
                skillDescriptions[2].GetComponentInChildren<TextMeshProUGUI>().text = extraAtackTxt;
                break;
        }
    }

    private void makeSkillActive(int indexOfSkill)
    {
        Color color = skillsIcons[indexOfSkill].GetComponent<Image>().color;
        color.a = 1f;
        skillsIcons[indexOfSkill].GetComponent<Image>().color = color;
    }

    private void makeSkillUnactive(int indexOfSkill)
    {
        Color color = skillsIcons[indexOfSkill].GetComponent<Image>().color;
        color.a = 0.5f;
        skillsIcons[indexOfSkill].GetComponent<Image>().color = color;
    }

    private void updateCoins(int value)
    {
        coinText.SetText("x"+value.ToString());
        int additionalX = value.ToString().Length;
        float xCoordinate = -(88 + (additionalX - 1) * 20);
        coin.GetComponent<RectTransform>().anchoredPosition = new Vector3(xCoordinate, -50f, 0f);
    }

    private void skillbarsUpdate()
    {
        switch (hero)
        {
            case 0:
                mainSkillCooldown.value = mainSkill.GetComponent<TwardowskiMainAttack>().attackCooldown / skills[0].GetCooldown();

                secondSkillCooldown.value = secondSkill.GetComponent<TwardowskiSpecialAttack>().attackCooldown / skills[1].GetCooldown();
                break;
            //change to sawa abilities skills
            case 1:
                mainSkillCooldown.value = mainSkill.GetComponent<SawaMainAttack>().attackCooldown / skills[0].GetCooldown();

                secondSkillCooldown.value = secondSkill.GetComponent<SawaSpecialAbility>().attackCooldown / skills[1].GetCooldown();
                break;
        }
        if (mainSkillCooldown.value == 0)
        {
            mainSkillCooldown.gameObject.SetActive(false);
        }
        else
        {
            mainSkillCooldown.gameObject.SetActive(true);
        }
        if (secondSkillCooldown.value == 0)
        {
            secondSkillCooldown.gameObject.SetActive(false);
        }
        else
        {
            secondSkillCooldown.gameObject.SetActive(true);
        }
    }

}
