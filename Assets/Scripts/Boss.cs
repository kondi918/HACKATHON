using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject pudieSidekick;
    [SerializeField] GameObject shootingSidekick;
    [SerializeField] GameController gameController;
    [SerializeField] GameObject room;
    float summonCD = 0;

    [SerializeField] GameObject projectileExample;
    //[SerializeField] float reload = 1f;
    [SerializeField] float projectileSpeed = 10f;
    private Vector3 direction = Vector3.zero;

    [SerializeField] float movingSpeed = 1f;

    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shoting());
    }

    // Update is called once per frame
    void Update()
    {
        if (summonCD > 0) 
        {
            summonCD -= Time.deltaTime;
        }
        else if (TestIfRoomClear())
        {
            SummonSidekicks();
        }
    }
    private bool TestIfRoomClear()
    {
        Transform[] transforms = room.GetComponentsInChildren<Transform>();
        bool roomIsClear = true;

        foreach (Transform t in transforms)
        {
            if (LayerMask.LayerToName(t.gameObject.layer) == "Enemy")
            {
                roomIsClear = false;
            }
        }

        return roomIsClear;
    }

    void SummonSidekicks()
    {
        SummonSidekick(pudieSidekick);
        SummonSidekick(pudieSidekick);
        SummonSidekick(shootingSidekick);
        summonCD = 10f;
    }

    void SummonSidekick(GameObject sidekick)
    {
        GameObject newSidekick = Instantiate(sidekick);
        newSidekick.transform.SetParent(room.transform);
        newSidekick.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-8, 8));
        newSidekick.SetActive(true);
    }

    private void Shot(float degree)
    {
        Quaternion rotationQuaternion = Quaternion.Euler(0, 0, degree);

        direction = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0) - GetPlayerPosition();

        GameObject projectile = Instantiate(projectileExample);
        projectile.transform.SetLocalPositionAndRotation(gameObject.transform.position, gameObject.transform.rotation);
        projectile.SetActive(true);
        projectile.GetComponent<Rigidbody2D>().velocity = rotationQuaternion * direction.normalized * projectileSpeed * -1;
        Destroy(projectile, 5f);
    }

    

    private Vector3 GetPlayerPosition()
    {
        return new Vector3(player.transform.position.x, player.transform.position.y, 0);
    }

    IEnumerator shoting()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 3f));
        Shot(0);
        Shot(15);
        Shot(-15);
        StartCoroutine(shoting());
    }
}
