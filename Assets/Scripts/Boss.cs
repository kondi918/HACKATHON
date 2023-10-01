using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject pudieSidekick;
    [SerializeField] GameObject shootingSidekick;
    [SerializeField] GameController gameController;
    float summonCD = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (summonCD > 0) 
        {
            summonCD -= Time.deltaTime;
        }
        if (summonCD <= 0 && gameController.TestIfRoomClear())
        {
            SummonSidekicks();
        }
    }

    void SummonSidekicks()
    {
        SummonSidekick(pudieSidekick);
        SummonSidekick(pudieSidekick);
        SummonSidekick(shootingSidekick);
    }

    void SummonSidekick(GameObject sidekick)
    {
        GameObject newSidekick = Instantiate(sidekick);
        newSidekick.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-8, 8));
        sidekick.SetActive(true);
    }
}
