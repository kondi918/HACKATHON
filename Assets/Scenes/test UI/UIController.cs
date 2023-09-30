using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    [SerializeField] private Sprite[] hearthSprites;
    [SerializeField] private GameObject hearth;
    private List<GameObject> hearthsOnScreen = new List<GameObject>();


    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameObject coin;
    
    private Transform canvasTransform;
    private int mn = 6;
    private int coinquan = 100;
    private int maxHealth = 10;
    private int curHealth = 6;
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
        //testing
        updateHealth(mn);
        if (Input.GetKeyDown(KeyCode.W)) {
            mn--;
            //addHealth();
        }
        updateCoins(coinquan);
        if (Input.GetKeyDown(KeyCode.S)) { 
            coinquan--;
            addHearth();
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

    }

    private void updateCoins(int value)
    {
        coinText.SetText("x"+value.ToString());
        int additionalX = value.ToString().Length;
        float xCoordinate = -(88 + (additionalX - 1) * 20);
        coin.GetComponent<RectTransform>().anchoredPosition = new Vector3(xCoordinate, -50f, 0f);
    }

}
