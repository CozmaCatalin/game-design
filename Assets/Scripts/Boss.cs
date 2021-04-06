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
    public GameObject projectile;

    public bool isMakinSpecialAttack1 = false;


    private void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("BossHealth").GetComponent<Slider>();
        healthBar.GetComponent<Animator>().SetTrigger("slideLeft");
        anim = GetComponent<Animator>();
        health = 150;
        damage = 10;
    }

    private void Update()
    {
        if (!isMakinSpecialAttack1)
        {
            StartCoroutine(SpecialAttack());
        }

        if (health <= 75) {
            anim.SetTrigger("stageTwo");
            damage = 20;

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


    IEnumerator SpecialAttack()
    {
        isMakinSpecialAttack1 = true;
        yield return new WaitForSeconds(5f);
        for(int i = 0; i < 18; i++)
        {
            GameObject instantiatedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            instantiatedProjectile.GetComponent<BossProjectile>().goingDirection = i * 20;
        }
        isMakinSpecialAttack1 = false;
        Debug.Log("Special attack maded!");
    }


    public void TakeDamage(int damage)
    {
        Debug.Log("Taking " + damage + " from boss");
        Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }
}
