using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class UIController : MonoBehaviour
{

    [SerializeField] private Sprite[] hearthSprites;
    [SerializeField] private GameObject hearth;
    private List<GameObject> hearthsOnScreen = new List<GameObject>();


    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameObject coin;


    [SerializeField] private GameObject[] skillsIcons;
    
    private Transform canvasTransform;
    private int health = 6;
    private int coinCount = 100;
    private int maxHealth = 10;
    private int curHealth = 6;

    [SerializeField] private Powerup[] skills;


    [SerializeField] GameObject player;
    [SerializeField] GameObject[] abillities;

    [SerializeField] private Slider mainSkillCooldown;
    [SerializeField] private GameObject mainSkill;

    [SerializeField] private Slider secondSkillCooldown;
    [SerializeField] private GameObject secondSkill;

    // Start is called before the first frame update
    void Start()
    {
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
        updateHealth(health);
        updateCoins(coinCount);
        updateSkills();
        skillbarsUpdate();
        
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
            if (skillsIcons[i].active!=true || skills[i].skillLevel == skills[i].skillMaxLevel)
            {
                makeSkillUnactive(i);
                continue;
                
            }
            if (coinCount >= skills[i].getCurrentUpgradeCost())
            {
                skillsIcons[i].GetComponent<SkillUpgrade>().isActive = true;
                makeSkillActive(i);
            }
            if (skillsIcons[i].GetComponent<SkillUpgrade>().isClicked == true)
            {
                skillsIcons[i].GetComponent<SkillUpgrade>().isClicked = false;
                skillsIcons[i].GetComponent<SkillUpgrade>().isActive = false;
                makeSkillUnactive(i);
                coinCount -= skills[i].getCurrentUpgradeCost();
                skills[i].skillLevel++;
            }
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
        mainSkillCooldown.value = mainSkill.GetComponent<TwardowskiMainAttack>().attackCooldown/ skills[0].GetCooldown();
        if(mainSkillCooldown.value == 0)
        {
            mainSkillCooldown.gameObject.SetActive(false);
        }
        else
        {
            mainSkillCooldown.gameObject.SetActive(true);
        }
        secondSkillCooldown.value= secondSkill.GetComponent<TwardowskiSpecialAttack>().attackCooldown / skills[1].GetCooldown();
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
