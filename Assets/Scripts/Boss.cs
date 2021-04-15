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
    public GameObject coin;
    public GameObject gameManager;
    public float waitForSpecialAttack1;

    public bool isMakinSpecialAttack1 = false;


    private void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("BossHealth").GetComponent<Slider>();
        healthBar.GetComponent<Animator>().SetTrigger("slideLeft");
        anim = GetComponent<Animator>();
        health = 150;
        damage = 10;
        waitForSpecialAttack1 = 5f;
    }

    private void Update()
    {
        if (!isMakinSpecialAttack1 && health > 0)
        {
            StartCoroutine(SpecialAttack());
        }

        if (health <= 75) {
            anim.SetTrigger("stageTwo");
            waitForSpecialAttack1 = 2f;
            damage = 20;

        }

        if (health <= 0) {
            anim.SetTrigger("death");
            GameObject.FindGameObjectWithTag("GamePlay").GetComponent<GamePlay>().roundDone = true;
            StartCoroutine(GiveCoins());
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
        yield return new WaitForSeconds(waitForSpecialAttack1);
        if(health > 0)
        {
            for (int i = 0; i < 18; i++)
            {
                GameObject instantiatedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
                instantiatedProjectile.GetComponent<BossProjectile>().goingDirection = i * 20;
            }
        }
        //Debug.Log("Special attack maded!");
        isMakinSpecialAttack1 = false;

    }

    IEnumerator GiveCoins()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 18; i++)
        {
            GameObject coinInstantiated = Instantiate(coin, transform.position, Quaternion.identity);
            coinInstantiated.transform.Rotate(0, 0, i*20, 0);
            coinInstantiated.transform.Translate(Vector2.up * 10f * Time.deltaTime);
        }
        Destroy(gameObject);
    }


    public void TakeDamage(int damage)
    {
        //Debug.Log("Taking " + damage + " from boss");
        Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }
}
