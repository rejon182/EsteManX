using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortraitController : MonoBehaviour
{
    public int activatedCandle = 0;
    public int requiredCandles = 3; // Adjust as needed
    public GameObject portrait;
    private SpriteRenderer portraitSprite;
    

    private void Start()
    {
        portrait.SetActive(false);

    }

    private void Update()
    {
        CheckPortraitState();
        
    }

    public void CheckPortraitState()
    {
        if (activatedCandle >= requiredCandles)
        {
            portrait.SetActive(true);
            portraitSprite = GetComponent<SpriteRenderer>();
        }
    }

    public void ActivatePortrait()
    {
        portrait.SetActive(true);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Mostrando al niño");
        portraitSprite.color = Color.green;
    }
}
