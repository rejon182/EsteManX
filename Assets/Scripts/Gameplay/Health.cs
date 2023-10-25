using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
	
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
