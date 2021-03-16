using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword3 : MonoBehaviour, IWeapon
{
    public List<BaseStat> Stats { get; set; }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<EnemyController>().TakeDamage(Stats[0].GetCalculatedStatValue());
            Debug.Log("sword3 " + Stats[0].GetCalculatedStatValue() + " damage from enemy");
        }
    }
}
