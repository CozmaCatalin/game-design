﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProjectille : MonoBehaviour
{
    public GameObject destroyEffect;
    public float speed;
    public int damage = 5;
    private Transform player;
    private Vector2 target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
    {
        if (transform.position.x < player.transform.position.x)
        {
            transform.eulerAngles = Vector3.forward * -90f;
        }
        else
        {
            transform.eulerAngles = Vector3.forward * 90f;

        }
        
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player hitted");
            collision.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}