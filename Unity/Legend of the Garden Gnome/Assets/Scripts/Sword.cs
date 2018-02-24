using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;

    public List<BaseStat> stats { get; set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        animator.SetTrigger("Base_Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<IEnemy>().TakeDamage(stats[0].GetCalculatedStatValue());
        }
    }
}
