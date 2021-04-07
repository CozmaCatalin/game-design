using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProjectilleSwordMan : MonoBehaviour
{
    public int damage = 5;


    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Player hitted by the sword");
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
