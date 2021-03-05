using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon;

    PlayerStat playerStat;
    IWeapon equippedWeapon;

    void Start()
    {
        playerStat = GetComponent<PlayerStat>();
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if (EquippedWeapon != null)
        {
            //playerStat.RemoveStatBonus(EquippedWeapon);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }
        Debug.Log(playerHand.transform.position);
        EquippedWeapon = Instantiate(Resources.Load<GameObject>("Weapon/"+itemToEquip.ObjectSlug),
            playerHand.transform.position,playerHand.transform.rotation);
        //equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        //Debug.Log(equippedWeapon);
        //equippedWeapon.Stats = itemToEquip.Stats;
        EquippedWeapon.transform.SetParent(playerHand.transform);
        playerStat.AddStatBonus(itemToEquip.Stats);
        //Debug.Log(equippedWeapon.Stats[0].BaseValue);
    }

    public void PerformWeaponAttack()
    {
        //equippedWeapon.PerformAttack();
    }
}
