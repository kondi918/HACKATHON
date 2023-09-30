using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingEnemy : MonoBehaviour
{
    [SerializeField] GameObject projectileExample;
    [SerializeField] float reload = 1f;
    [SerializeField] float projectileSpeed = 10f;
    private Vector3 direction = Vector3.zero;

    [SerializeField] float movingSpeed = 1f;

    [SerializeField] GameObject player;


    void Start()
    {
        StartCoroutine(shoting());
    }

    private void Shot()
    {
        direction = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0) - GetPlayerPosition();

        GameObject projectile = Instantiate(projectileExample);
        projectile.transform.SetLocalPositionAndRotation(gameObject.transform.position, gameObject.transform.rotation);
        projectile.SetActive(true);
        projectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * projectileSpeed * -1;
        Destroy(projectile, 5f);
    }

    IEnumerator shoting()
    {
        yield return new WaitForSeconds(reload);
        Shot();
        StartCoroutine(shoting());
    }

    // Update is called once per frame
    void Update()
    {
        StartMovingModel();
    }

    private void StartMovingModel()
    {
        direction = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0) - GetPlayerPosition();

        float distance = (new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0) - 
            GetPlayerPosition()).magnitude;

        if (distance > 10)
        {
            gameObject.transform.position = gameObject.transform.position + direction.normalized * movingSpeed * Time.deltaTime * -1;
        }
    }

    private Vector3 GetPlayerPosition()
    {
        return new Vector3(player.transform.position.x, player.transform.position.y, 0);
    }
}
