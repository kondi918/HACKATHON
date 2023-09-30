using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject extraSkill;
    [SerializeField] private List<GameObject> rooms;
    private int currentRoom = 0;


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

    private void Start()
    {
        StartCoroutine(LoadRoom());
    }

    public void GoToNextRoom()
    {
        Debug.Log("Going to next room");
    }

    public void TestIfRoomClear()
    {
        Transform[] transforms = rooms[currentRoom].GetComponentsInChildren<Transform>();
        bool roomIsClear = true;

        foreach (Transform t in transforms)
        {
            if (LayerMask.LayerToName(t.gameObject.layer) == "Enemy")
            {
                roomIsClear = false;
            }
        }
        
        if (roomIsClear)
        {
            GoToNextRoom();
        }
    }

    IEnumerator LoadRoom()
    {
        yield return new WaitForSeconds(1.5f);
        if (rooms.Count > currentRoom)
        {
            rooms[currentRoom].gameObject.SetActive(true);
        }
    }
}
