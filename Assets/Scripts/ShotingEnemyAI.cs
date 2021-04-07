using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingEnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Stats")]
    public float speed;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBtwShots;
    private float timeBtwShots1;
    private float timeBtwShots2;
    private float timeBtwShots3;
    public float waitTimeToAttack;

    public GameObject shot;
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nearDistance = Random.Range(20, 25);
        stoppingDistance = Random.Range(15, 25);
        startTimeBtwShots = 3;
        speed = Random.Range(5, 10);
        waitTimeToAttack = 1;
        timeBtwShots1 = 1.1f;
        timeBtwShots2 = 1.3f;
        timeBtwShots3 = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        waitTimeToAttack -= Time.deltaTime;
        if (player != null)
        {
            if (transform.position.x > player.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);

            }
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (Mathf.Abs(distanceToPlayer - stoppingDistance) <= 1f || Mathf.Abs(distanceToPlayer - nearDistance) <= 1f)
            {
                //Debug.Log("[1]");
            }
            else if (distanceToPlayer > stoppingDistance)
            {
                //Debug.Log("[2]");
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (distanceToPlayer < nearDistance)
            {
                //Debug.Log("[3]");
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            if (timeBtwShots1 < 0 && waitTimeToAttack < 0)
            {
                Instantiate(shot, transform.position, Quaternion.identity);
                timeBtwShots1 = startTimeBtwShots;
            }
            else
            {
                timeBtwShots1 -= Time.deltaTime;
            }

            if (timeBtwShots2 < 0 && waitTimeToAttack < 0)
            {
                Instantiate(shot, transform.position, Quaternion.identity);
                timeBtwShots2 = startTimeBtwShots;
            }
            else
            {
                timeBtwShots2 -= Time.deltaTime;
            }

            if (timeBtwShots3 < 0 && waitTimeToAttack < 0)
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

