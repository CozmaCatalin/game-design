using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword2 : MonoBehaviour, IWeapon
{
    public List<BaseStat> Stats { get; set; }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue());
            Debug.Log("sword2 " + Stats[0].GetCalculatedStatValue() + " damage from enemy");
        }
    }
}
