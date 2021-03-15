using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon;
    public Transform swordPivot;

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
            playerStat.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }
        EquippedWeapon = Instantiate(Resources.Load<GameObject>("Weapon/"+itemToEquip.ObjectSlug),
            playerHand.transform.position,
            swordPivot.rotation
         );
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        equippedWeapon.Stats = itemToEquip.Stats;
        EquippedWeapon.transform.SetParent(playerHand.transform);
        playerStat.AddStatBonus(itemToEquip.Stats);
        Debug.Log(equippedWeapon.Stats[0].BaseValue);
    }

    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.Mouse0) && equippedWeapon != null)
      //  {
      //      PerformWeaponAttack();
     //   }
    }

}
