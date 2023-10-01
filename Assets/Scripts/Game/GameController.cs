using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject extraSkill;
    [SerializeField] private List<GameObject> rooms;
    public int currentRoom = 0;

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

    public void SetCurrentRoom(int roomIndex)
    {
        if (roomIndex < rooms.Count) 
        {
            currentRoom = roomIndex;
        }
        else
        {
            Debug.Log("Index out off bounds");
        }
    }

    public GameObject GetCurrentRoom()
    {
        return rooms[currentRoom];
    }

    private void Start()
    {
        StartCoroutine(LoadRoom());
    }

    public void GoToNextRoom()
    {
        Debug.Log("Going to next room");
    }

    public bool TestIfRoomClear()
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
        //Debug.Log("1");
        
        return roomIsClear;
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
