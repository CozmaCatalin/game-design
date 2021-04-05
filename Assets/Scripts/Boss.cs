using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour,IEnemy {

    public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;


    public Slider healthBar;
    private Animator anim;
    public bool isDead;
    public GameObject explosion;


    private void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("BossHealth").GetComponent<Slider>();
        healthBar.GetComponent<Animator>().SetTrigger("slideLeft");
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (health <= 25) {
            anim.SetTrigger("stageTwo");
        }

        if (health <= 0) {
            anim.SetTrigger("death");
        }

        // give the player some time to recover before taking more damage !
        if (timeBtwDamage > 0) {
            timeBtwDamage -= Time.deltaTime;
        }

        healthBar.value = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // deal the player damage ! 
        if (other.CompareTag("Player") && isDead == false) {
            if (timeBtwDamage <= 0) {
                other.GetComponent<PlayerController>().TakeDamage(damage);
            }
        } 
    }


    public void TakeDamage(int damage)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }
}
