using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
    public GameObject playerHand;
    public GameObject equippedWeapon { get; set; }

    IWeapon equippedIWeapon;
    CharacterStats characterStats;

    private void Start()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    public void EquipWeapon(Item _itemToEquip)
    {
        if (equippedWeapon != null)
        {
            characterStats.RemoveStatBonus(equippedWeapon.GetComponent<IWeapon>().stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        } //Hand is now empty

        equippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + _itemToEquip.objectSlug), 
            playerHand.transform.position, playerHand.transform.rotation);
        equippedIWeapon = equippedWeapon.GetComponent<IWeapon>();
        equippedIWeapon.stats = _itemToEquip.stats;
        equippedWeapon.transform.SetParent(playerHand.transform);
        characterStats.AddStatBonus(_itemToEquip.stats);
        Debug.Log("Equippedweapon stats: " + equippedIWeapon.stats[0].GetCalculatedStatValue());
    }

    public void PerformWeaponAttack()
    {
        equippedIWeapon.PerformAttack();
    }
}
