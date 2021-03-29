using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Stats")]
    public float speed;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBtwShots;
    public float timeBtwShots1;
    public float timeBtwShots2;
    public float timeBtwShots3;

    public GameObject shot;
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) < nearDistance)
            {
                //Debug.Log("[1]" + Vector2.Distance(transform.position, player.position));
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                //Debug.Log("[2]" + Vector2.Distance(transform.position, player.position));
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) - stoppingDistance <= 1f && Vector2.Distance(transform.position, player.position) - nearDistance <= 1f)
            {
                //Debug.Log("[3]" + Vector2.Distance(transform.position, player.position));
                transform.position = this.transform.position;
            }

            if (timeBtwShots1 < 0)
            {
                Instantiate(shot, transform.position, Quaternion.identity);
                timeBtwShots1 = startTimeBtwShots;
            }
            else
            {
                timeBtwShots1 -= Time.deltaTime;
            }
            if (timeBtwShots2 < 0)
            {
                Instantiate(shot, transform.position, Quaternion.identity);
                timeBtwShots2 = startTimeBtwShots;
            }
            else
            {
                timeBtwShots2 -= Time.deltaTime;
            }
            if (timeBtwShots3 < 0)
            {
                Instantiate(shot, transform.position, Quaternion.identity);
                timeBtwShots3 = startTimeBtwShots;
            }
            else
            {
                timeBtwShots3 -= Time.deltaTime;
            }
        }
    }
}
