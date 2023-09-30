using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RatTrappersFlateSkill : MonoBehaviour
{
    bool reloaded = true;
    [SerializeField] float reloadTime = 5;
    [SerializeField] GameObject rat;
    [SerializeField] Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        ListenInput();
    }

    private void ListenInput()
    {
        if (Input.GetKeyDown(KeyCode.R) && reloaded)
        {
            ActivateSkill();
        }
    }

    void ActivateSkill()
    {
        for (int i = 0; i < 3; i++)
        {
            SummonRat();
        }

        reloaded = false;
        StartCoroutine(reload());
    }

    void SummonRat()
    {
        

        Instantiate(rat, playerTransform).SetActive(true);
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(reloadTime);
        reloaded = true;
    }
}
