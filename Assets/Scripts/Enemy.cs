using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour,IEnemy {

    //public Animator camAnim;
    public int health;
    public GameObject deathEffect;
    public GameObject explosion;
    public GameObject coin;
    public float speed = 5;
    public Animator animator;
    const float map1MobSize = 0.5f;
    const float map2MobSize = 1f;
    const float map3MobSize = 1.5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Map1")
        {
            health = health * 1 * (ShopManager.gameDifficulty);
            float value = Random.Range(0, map1MobSize);
            gameObject.transform.localScale += new Vector3(value, value, 0);
        }

        if (sceneName == "Map3")
        {
            health = health * 2 * (ShopManager.gameDifficulty);
            float value = Random.Range(0, 0);
            gameObject.transform.localScale += new Vector3(value, value, 0);
        }
        if (sceneName == "Map4")
        {
            health = health * 3 * (ShopManager.gameDifficulty);
            float value = Random.Range(0, map3MobSize);
            gameObject.transform.localScale += new Vector3(value, value, 0);
        }

    }

    private void Update()
    {
        if (health <= 0) {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(coin, transform.position, Quaternion.identity);
            if(animator != null)
            {
                Destroy(gameObject);
            } else {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            GameObject.FindGameObjectWithTag("GamePlay").GetComponent<GamePlay>().currentMonsters -= 1;
        }
    }

    public void TakeDamage(int damage) {
        //camAnim.SetTrigger("shake");
        //Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            health = 0;
        }

    }

}
