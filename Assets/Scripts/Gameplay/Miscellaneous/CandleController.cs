using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour
{
    public PortraitController portrait;
    public GameObject candle;
    private SpriteRenderer candleSprite;
    private bool isActive;
    private Animator animator;

    private void Awake()
    {
        candleSprite = GetComponent<SpriteRenderer>();  
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        portrait.CheckPortraitState();
        animator.SetBool("IsCandleON", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("XD");
        if (other.CompareTag("Player") && !isActive) // Adjust the tag as needed
        {
            portrait.activatedCandle++;
            portrait.CheckPortraitState();
            AudioManager.Instance.PlaySFX("sfx_candle");
            isActive = true;
            animator.SetBool("IsCandleON", true);
            // portrait.ActivatePortrait();
        }
    }
}