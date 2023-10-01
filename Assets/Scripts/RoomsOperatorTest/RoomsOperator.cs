using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsOperator : MonoBehaviour
{
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private GameController gameController;
    private GameObject room;
    [SerializeField] private GameObject lastRoom;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bossRoom;
    private int roomCount=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void loadRoom()
    {
        if (roomCount == 5)
        {
            room = Instantiate(bossRoom, new Vector3(0, 0, 5f), Quaternion.Euler(0, 0, 0));
            player.transform.position = new Vector3(-14, 0, -5);
            ChasePlayer[] Padie = room.GetComponentsInChildren<ChasePlayer>();
            ShotingEnemy[] enemie = room.GetComponentsInChildren<ShotingEnemy>();
            Boss bos = room.GetComponentInChildren<Boss>();
            bos.gameController = gameController;
            bos.player = player;
            foreach (ChasePlayer pudy in Padie)
            {
                pudy.target = player.transform;
                pudy.gameController = gameController;
                pudy.gameObject.SetActive(false);
            }
            foreach (ShotingEnemy enemy in enemie)
            {
                enemy.player = player;
                enemy.gameController = gameController;
                enemy.gameObject.SetActive(false);
            }
            gameController.currentRoom = 3;
            lastRoom = room;

        }
        else
        {
            int num = Random.Range(0, rooms.Length);
            room = Instantiate(rooms[num], new Vector3(0, 0, 5), Quaternion.Euler(0, 0, 0));
            player.transform.position = new Vector3(-14, 0, -5);
            ChasePlayer[] Padies = room.GetComponentsInChildren<ChasePlayer>();
            ShotingEnemy[] enemies = room.GetComponentsInChildren<ShotingEnemy>();
            foreach (ChasePlayer pudy in Padies)
            {
                pudy.target = player.transform;
                pudy.gameController = gameController;
            }
            foreach (ShotingEnemy enemy in enemies)
            {
                enemy.player = player;
                enemy.gameController = gameController;
            }
            gameController.currentRoom = num;
            lastRoom = room;
        }
    }

    public bool checkRoom()
    {
        Transform[] t = lastRoom.transform.GetComponentsInChildren<Transform>();
        foreach(Transform t1 in t)
        {
            if (LayerMask.LayerToName(t1.gameObject.layer) == "Enemy")
            {
                return false;
            }
        }
        return true;
    }

    public void loadNext()
    {
        roomCount++;
        Destroy(lastRoom);
        loadRoom();
    } 

    // Update is called once per frame
}
