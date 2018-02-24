using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
    public GameObject playerHand;
    public GameObject equippedWeapon { get; set; }

    Transform spawnProjectile;
    IWeapon equippedIWeapon;
    CharacterStats characterStats;

    private void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        spawnProjectile = transform.FindChild("ProjectileSpawn");
    }

    public void EquipWeapon(Item _itemToEquip)
    {
        if (equippedWeapon != null) //If the hand is not empty
        {
            characterStats.RemoveStatBonus(equippedWeapon.GetComponent<IWeapon>().stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        } //Hand is now empty

        equippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + _itemToEquip.objectSlug), 
            playerHand.transform.position, playerHand.transform.rotation);
        equippedIWeapon = equippedWeapon.GetComponent<IWeapon>();
        if (equippedWeapon.GetComponent<IProjectileWeapon>() != null)
            equippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        equippedIWeapon.stats = _itemToEquip.stats;
        equippedWeapon.transform.SetParent(playerHand.transform);
        characterStats.AddStatBonus(_itemToEquip.stats);
        Debug.Log("Equippedweapon stats: " + equippedIWeapon.stats[0].GetCalculatedStatValue());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PerformWeaponAttack();
        }
    }

    public void PerformWeaponAttack()
    {
        equippedIWeapon.PerformAttack();
    }
}
