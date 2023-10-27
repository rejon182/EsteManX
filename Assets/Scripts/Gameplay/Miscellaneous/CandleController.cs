using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour
{
    public PortraitController portrait;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Adjust the tag as needed
        {
            portrait.activatedCandle++;
            portrait.CheckPortraitState();
        }
    }
}
