using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryHealthController : MonoBehaviour
{
    [SerializeField] private int healthRecover;
    [SerializeField] private Health _health;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("HealthItem") && _health.health < 3)
        {
            RecoverHealth();
            col.gameObject.SetActive(false);
        }
    }

    public void RecoverHealth()
    {
        _health.health += healthRecover;
        _health.UpdateHealth();
    }
}