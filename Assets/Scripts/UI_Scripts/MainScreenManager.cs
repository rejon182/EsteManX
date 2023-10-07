using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelCredits;

    private void Awake()
    {
        
    }

    void Start()
    {
        AudioManager.instance.PlayMusic("MainMenu");
        panelMenu.SetActive(true);
        panelCredits.SetActive(false);
    }

    #region Update

    // Update is called once per frame
    void Update()
    {
    }

    #endregion

    public void StartGame()
    {
        SceneManager.LoadScene("Ingame");
        Debug.Log("Prueba de press");
    }

    public void ShowCredits()
    {
        SwitchMenuPanelState();
        SwitchCreditsPanelState();
        Debug.Log("Show credits: " + panelCredits.activeInHierarchy);
    }

    public void ExitGameApp()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    private void SwitchMenuPanelState()
    {
        if (panelMenu.activeInHierarchy)
        {
            panelMenu.SetActive(false);
        }
        else
        {
            panelMenu.SetActive(true);
        }
    }

    private void SwitchCreditsPanelState()
    {
        if (panelCredits.activeInHierarchy)
        {
            panelCredits.SetActive(false);
        }
        else
        {
            panelCredits.SetActive(true);
        }
    }
}