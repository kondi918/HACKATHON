using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject pudieSidekick;
    [SerializeField] GameObject shootingSidekick;
    [SerializeField] GameController gameController;
    [SerializeField] GameObject room;
    float summonCD = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameController.SetCurrentRoom(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (summonCD > 0) 
        {
            summonCD -= Time.deltaTime;
        }
        else if (gameController.TestIfRoomClear())
        {
            SummonSidekicks();
        }
    }

    void SummonSidekicks()
    {
        SummonSidekick(pudieSidekick);
        SummonSidekick(pudieSidekick);
        SummonSidekick(shootingSidekick);
        summonCD = 10f;
    }

    void SummonSidekick(GameObject sidekick)
    {
        GameObject newSidekick = Instantiate(sidekick);
        newSidekick.transform.SetParent(room.transform);
        newSidekick.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-8, 8));
        newSidekick.SetActive(true);
    }
}
