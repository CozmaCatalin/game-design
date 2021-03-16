using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour,IEnemy
{
    public float currentHealth, power, toughness;
    public float maxHealth = 20;
    public int hitValue = 5;
    public Text scoreText;
    public GameObject gamePlay;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerStat>().health -= hitValue;
            Debug.Log("Enemy take " + hitValue + " damage");
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gamePlay.GetComponent<Levels>().EnemyKilled();
        scoreText.text = "Enemyes left to kill " + gamePlay.GetComponent<Levels>().enemyesLeft;
        Destroy(gameObject);
    }
}