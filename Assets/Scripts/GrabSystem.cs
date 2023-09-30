using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    private float AttackSpeedIncreaseTime = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AttackSpeedBoost")
        {
            Destroy(collision.gameObject);
            ParametersHandler.atackSpeedScale = 0.5f;
            AttackSpeedIncreaseTime = 10;
        }
        else if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            Debug.Log("Increase money counter");
        }
    }

    private void Update()
    {
        if (AttackSpeedIncreaseTime > 0)
        {
            AttackSpeedIncreaseTime -= Time.deltaTime;
            if (!(AttackSpeedIncreaseTime > 0))
            {
                ParametersHandler.ResetAtackSpeedScale();
            }
        }
    }
}
