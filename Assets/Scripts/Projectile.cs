﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    public string tagFinded;
    public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null) {
            tagFinded = hitInfo.collider.tag;
            if (hitInfo.collider.CompareTag("Enemy")) {
                hitInfo.collider.GetComponent<IEnemy>().TakeDamage(damage);
            }
            DestroyProjectile();
        } else
        {
            tagFinded = null;
        }


        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile() {
        if(tagFinded != "Enemy" && tagFinded != "Boss")
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }
       
        Destroy(gameObject);
    }
}
