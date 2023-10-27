using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    [SerializeField] private Image[] hearts;

    private void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].color = Color.white;
            }
            else
            {
                hearts[i].color = Color.gray;
            }
        }
    }
    

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);			
        }
    }
	
    public void TakeHealth(int vida)
    {
        health += vida;
        if (health >= 100)
        {
            health = 100;
        }
    }
}
