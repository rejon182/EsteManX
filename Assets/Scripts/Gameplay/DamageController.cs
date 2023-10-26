using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
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
