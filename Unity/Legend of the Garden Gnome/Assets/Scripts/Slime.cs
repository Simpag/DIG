using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy {

    public float maxHealth, power, toughness;
    [SerializeField]
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void PerformAttack()
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int _amount)
    {
        currentHealth -= _amount;
        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
