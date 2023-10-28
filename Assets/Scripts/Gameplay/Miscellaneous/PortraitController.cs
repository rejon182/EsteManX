using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitController : MonoBehaviour
{
    public int activatedCandle = 0;
    public int requiredCandles = 3; // Adjust as needed
    public GameObject portrait;
    [SerializeField] private GameObject[] Candles;


    private void Update()
    {
        CheckPortraitState();
    }

    public void CheckPortraitState()
    {
        if (activatedCandle >= requiredCandles)
        {
            portrait.SetActive(true);
        }
    }
}
