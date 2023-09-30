using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Sprite[] hearthSprites;
    [SerializeField] private GameObject hearth;
    private List<GameObject> hearthsOnScreen=new List<GameObject>();
    private Transform canvasTransform;
    private int mn = 6;
    private int maxHealth = 6;
    // Start is called before the first frame update
    void Start()
    {
        canvasTransform = GetComponent<Transform>();
        createHearths(maxHealth/2);
       
    }

    // Update is called once per frame
    void Update()
    {
        updateHealth(mn);
        if (Input.GetKeyDown(KeyCode.W)) {
            mn--;
            //addHealth();
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
        int xCoordinate = (int)hearthsOnScreen[hearthsOnScreen.Count - 1].transform.position.x+75;
        hearthsOnScreen.Add(Instantiate(hearth, new Vector3(xCoordinate, 50, 0), Quaternion.Euler(0, 0, 0)));
        hearthsOnScreen[hearthsOnScreen.Count-1].transform.parent = canvasTransform;
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

}
