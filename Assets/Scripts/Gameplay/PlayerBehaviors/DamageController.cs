using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private Health _health;

    private void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Bullet"))
        {
            Damage();
            if (col.gameObject.CompareTag("Bullet"))
            {
                col.gameObject.SetActive(false);
            }
        }
    }

    public void Damage()
    {
        if (_health.health>=0)
        {
            _health.health -= damage;
            _health.UpdateHealth();
        }
    }
}