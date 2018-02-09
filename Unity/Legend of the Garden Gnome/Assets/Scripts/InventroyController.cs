using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventroyController : MonoBehaviour {
    public PlayerWeaponController playerWeaponController;
    public Item sword;
    
    void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        List<BaseStat> swordSats = new List<BaseStat>();
        swordSats.Add(new BaseStat(6, "Damage", "Your damage amount"));
        sword = new Item(swordSats, "Sword");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            playerWeaponController.EquipWeapon(sword);
        }
    }
}
