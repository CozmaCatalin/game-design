using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatSword : MonoBehaviour,IWeapon
{
    public List<BaseStat> Stats { get; set; }
    public GameObject swordPivot;

    public void PerformAttack()
    {
        Debug.Log("GreatSword Attack!");
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Enemy"))
        {
            col.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue());
            Debug.Log("Take " + Stats[0].GetCalculatedStatValue() + " damage from enemy");
        }
    }
}
