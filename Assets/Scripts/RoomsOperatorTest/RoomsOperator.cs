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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void loadRoom()
    {
        int num =Random.Range(0, rooms.Length);
        room = Instantiate(rooms[num], new Vector3(0, 0, 5), Quaternion.Euler(0, 0, 0));
        player.transform.position = new Vector3(-14, 0, -5);
        ChasePlayer[] Padies = room.GetComponentsInChildren<ChasePlayer>();
        ShotingEnemy[] enemies= room.GetComponentsInChildren<ShotingEnemy>();
        foreach (ChasePlayer pudy in Padies)
        {
            pudy.target = player.transform;
            pudy.gameController = gameController;
        }
        foreach(ShotingEnemy enemy in enemies){
            enemy.player = player;
            enemy.gameController = gameController;
        }
        gameController.currentRoom = num;
        lastRoom = room;
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
        Destroy(lastRoom);
        loadRoom();
    } 

    // Update is called once per frame
}
