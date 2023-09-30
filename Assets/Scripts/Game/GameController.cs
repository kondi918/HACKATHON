using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject extraSkill;

    public void dropCoin(GameObject monster)
    {
        int chance = Random.Range(0, 100);
        if (chance > 40)
        {
            Instantiate(coin, monster.transform.position, Quaternion.Euler(0, 0, 0));
        }
        Destroy(monster);
    }

    public void dropExtraSkill(GameObject monster)
    {
        int chance = Random.Range(0, 100);
        if (chance > 90)
        {
            Instantiate(extraSkill, monster.transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
