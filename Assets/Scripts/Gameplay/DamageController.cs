using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private Health _health;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Damage();
        }
    }

    public void Damage()
    {
        _health.health = _health.health - damage;
        _health.UpdateHealth();
        // gameObject.SetActive(false);
    }
}