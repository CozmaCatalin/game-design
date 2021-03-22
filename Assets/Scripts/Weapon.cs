﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float offset;

    public GameObject projectile;
    public GameObject shotEffect;
    public Transform shotPoint;
    public Animator camAnim;
    private SpriteRenderer weaponSprite;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Start()
    {
        weaponSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Handles the weapon rotation
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (difference.x > 0)
        {
            weaponSprite.flipX = false;
        }
        else
        {
            weaponSprite.flipX = true;
        }
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                camAnim.SetTrigger("shake");
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else {
            timeBtwShots -= Time.deltaTime;
        }

       
    }
}