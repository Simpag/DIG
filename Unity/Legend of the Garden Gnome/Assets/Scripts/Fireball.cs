using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }

    private Vector3 spawnPosition;

    private float speed = 50f;

    private void Start()
    {
        Range = 20f;
        Damage = 5;
        GetComponent<Rigidbody>().AddForce(Direction * speed);
        spawnPosition = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(spawnPosition, transform.position) > Range)
        {
            Extinguish();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            other.transform.GetComponent<IEnemy>().TakeDamage(Damage);
        }
        Extinguish();
    }

    private void Extinguish()
    {
        Destroy(gameObject);
    }
}
