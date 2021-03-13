using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IEnemy
{
    public float currentHealth, power, toughness;
    public float maxHealth = 20;
    public int hitValue = 5;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Enemy OnTriggerEnter");
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerStat>().health -= hitValue;
            Debug.Log("Enemy take " + hitValue + " damage");
        }
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