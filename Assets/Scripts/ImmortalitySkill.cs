using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmortalitySkill : MonoBehaviour
{
    bool reloaded = true;
    [SerializeField] float reloadTime = 30;
    [SerializeField] MainCharacter mainCharacter;

    // Update is called once per frame
    void Update()
    {
        ListenInput();
    }

    private void ListenInput()
    {
        if (Input.GetKeyDown(KeyCode.F) && reloaded)
        {
            ActivateSkill();
        }
    }

    void ActivateSkill()
    {
        mainCharacter.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        mainCharacter.StartCoroutine(mainCharacter.InvincibilityCoroutine(5));
        reloaded = false;
        StartCoroutine(reload());
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(reloadTime);
        reloaded = true;
    }
}
