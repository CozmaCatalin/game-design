﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Stats")]
    public float speed;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBtwShots;
    private float timeBtwShots;
    public float waitTimeToAttack;

    public GameObject shot;
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nearDistance = Random.Range(25, 50);
        stoppingDistance = Random.Range(25, 30);
        startTimeBtwShots = Random.Range(2, 4);
        speed = Random.Range(5, 10);
        waitTimeToAttack = Random.Range(4, 6);
    }

    // Update is called once per frame
    void Update()
    {
        waitTimeToAttack -= Time.deltaTime;
        if(player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (Mathf.Abs(distanceToPlayer - stoppingDistance) <= 1f || Mathf.Abs(distanceToPlayer - nearDistance) <= 1f)
            {
            }
            else if (distanceToPlayer > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (distanceToPlayer < nearDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            if (timeBtwShots < 0 && waitTimeToAttack < 0)
            {
                Instantiate(shot, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
