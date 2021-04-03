using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IEnemy {

    //public Animator camAnim;
    public int health;
    public GameObject deathEffect;
    public GameObject explosion;
    public GameObject coin;
    public float speed = 5;

    private void Update()
    {
        if (health <= 0) {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(coin, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("GamePlay").GetComponent<GamePlay>().currentMonsters -= 1;
        }
    }

    public void TakeDamage(int damage) {
        //camAnim.SetTrigger("shake");
        //Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }
}
