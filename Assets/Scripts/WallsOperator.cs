using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsOperator : MonoBehaviour
{


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "EnemyBullet" || LayerMask.LayerToName(collision.gameObject.layer) == "FriendlyBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
