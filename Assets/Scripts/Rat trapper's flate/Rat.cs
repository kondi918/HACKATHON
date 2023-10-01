using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rat : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] ChasePlayer chasePlayer;
    GameObject monstersGroup;
    private Transform[] enemyTransforms;

    // Start is called before the first frame update
    void Start()
    {
        monstersGroup = gameController.GetCurrentRoom();
        Vector3 posIncrease = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
        gameObject.transform.position += posIncrease;

        enemyTransforms = monstersGroup.GetComponentsInChildren<Transform>();
        
        Debug.Log(enemyTransforms.Length);
        if (enemyTransforms.Length == 1)
        {
            chasePlayer.setTarget(enemyTransforms[0]);
        }
        else if (enemyTransforms.Length > 0)
        {
            int random = Random.Range(0, enemyTransforms.Length);
            chasePlayer.setTarget( enemyTransforms[random]);

        }
    }
}
