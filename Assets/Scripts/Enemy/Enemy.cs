using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IEnemy
{
    public float currentHealth, power, toughness;
    public float maxHealth = 20;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void PerformAttack()
    {
        Debug.Log("Enemy will atack!");
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
        Destroy(gameObject);
    }
}