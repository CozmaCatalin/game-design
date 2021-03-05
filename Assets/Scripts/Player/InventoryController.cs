using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public Item sword;
    public Item greatSword;
    public PlayerWeaponController playerWeaponController;

    void Start()
    {
        playerWeaponController.GetComponent<PlayerWeaponController>();
        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(6,"Power","Your power level"));
        sword = new Item(swordStats, "sword");

        List<BaseStat> greatSwordStat = new List<BaseStat>();
        greatSwordStat.Add(new BaseStat(6, "Power", "Your power level"));
        greatSword = new Item(greatSwordStat, "RB_Rapier");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            playerWeaponController.EquipWeapon(sword);
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            playerWeaponController.EquipWeapon(greatSword);
        }
    }
}
