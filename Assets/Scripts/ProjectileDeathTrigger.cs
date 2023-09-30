using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDeathTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Walls")
        {
            Destroy(gameObject);
        }
    }
}
