using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<Item> swords;
    public PlayerWeaponController playerWeaponController;

    void Start()
    {
        playerWeaponController.GetComponent<PlayerWeaponController>();
        swords = new List<Item>();
        for(int i = 1; i <=4; i++)
        {
            List<BaseStat> swordStats = new List<BaseStat>
            {
                new BaseStat(5 * i, "Power", "Power of the sword")
            };
            Item sword = new Item(swordStats, "sword" + i);
            swords.Add(sword);
        }
    }

    public void EquipWeapon(int Level)
    {
        Debug.Log("NEW LEVEL!");
        playerWeaponController.EquipWeapon(swords[Level-1]);
    }
}
